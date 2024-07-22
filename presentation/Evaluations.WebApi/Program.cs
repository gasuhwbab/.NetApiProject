using System.Reflection;
using Evaluations.Application.Common.Mappings;
using Evaluations.Application.Interfaces;
using Evaluations.Persistence;
using Evaluations.Application;
using Evaluations.Application.Evaluations.Queries.GetAverageProductsEvaluation;
using Evaluations.Application.Evaluations.Queries.GetUserEvaluations;
using Evaluations.Application.Evaluations.Queries.GetProductEvaluation;
using Evaluations.Application.Evaluations.Commands.CreateEvaluation;
using Evaluations.Application.Evaluations.Commands.DeleteEvaluation;
using Evaluations.Application.Evaluations.Commands.UpdateEvaluation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Evaluations.WebApi.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IEvaluationsDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AlowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/evaluations/average", (IMediator mediator, int page = 1, int page_size = 10) =>
    mediator.Send(new GetAverageProductsEvaluationQuery { Page = page, PageSize = page_size }, new CancellationToken { }))
    .Produces(StatusCodes.Status200OK)
    .WithName("GetAverageProductsEvaluations")
    .WithOpenApi();

app.MapGet("/evaluations/user/{id}", (Guid id, IMediator mediator) =>
    mediator.Send(new GetUserEvaluationsQuery { UserId = id }, new CancellationToken { }))
    .Produces(StatusCodes.Status200OK)
    .WithName("GetUserEvaluation")
    .WithOpenApi();

app.MapGet("/evaluations/product/{id}", (IMediator mediator, Guid id, int page = 1, int page_size = 10) =>
    mediator.Send(new GetProductEvaluationQuery
    {
        ProductId = id,
        Page = page,
        PageSize = page_size
    }, new CancellationToken { }))
    .Produces(StatusCodes.Status200OK)
    .WithName("GetProductEvaluation")
    .WithOpenApi();

app.MapPost("/evaluations",
    (IMediator mediator, IMapper mapper, [FromBody] CreateEvaluationDto newEvaluation) =>
    mediator.Send(mapper.Map<CreateEvaluationCommand>(newEvaluation), new CancellationToken { }))
    .Produces(StatusCodes.Status201Created)
    .WithName("InsertEvaluation")
    .WithOpenApi();

app.MapPut("/evaluations/{id}",
    (IMediator mediator, IMapper mapper, Guid id, [FromBody] UpdateEvaluationDto updatedEvaluation) =>
    {
        updatedEvaluation.Id = id;
        mediator.Send(mapper.Map<UpdateEvaluationCommand>(updatedEvaluation), new CancellationToken { });
    })
    .Produces(StatusCodes.Status200OK)
    .WithName("ChangeEvaliation")
    .WithOpenApi();

app.MapDelete("/evaluations/{id}",
    (IMediator mediator, Guid id) =>
    mediator.Send(new DeleteEvaluationCommand { Id = id }, new CancellationToken { }))
    .Produces(StatusCodes.Status200OK)
    .WithName("DeleteEvaluation")
    .WithOpenApi();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

InitDb(app);

app.Run();

static void InitDb(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services.GetRequiredService<IEvaluationsDbContext>());
}

