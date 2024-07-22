using Evaluations.Domain;
using MediatR;
using Evaluations.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Evaluations.Application.Evaluations.Commands.CreateEvaluation;

public class CreateEvaluationCommandHandler : IRequestHandler<CreateEvaluationCommand, Guid>
{
    private readonly IEvaluationsDbContext _dbContext;
    public CreateEvaluationCommandHandler(IEvaluationsDbContext dbContext) => 
        _dbContext = dbContext; 
    public async Task<Guid> Handle(CreateEvaluationCommand request, 
        CancellationToken cancellationToken)
    {   
        var isExistingEvaluation = _dbContext.Evaluations
            .Where(eval => eval.ProductId == request.ProductId && eval.UserId == request.UserId);

        if (isExistingEvaluation.Any())
        {
            throw new InvalidOperationException(
                "Invalid operation. You have already rated this product!");
        }
        var evaluation = new Evaluation
        {
            UserId = request.UserId,
            ProductId = request.ProductId,
            Value = request.Value,
            Id = Guid.NewGuid()
        };
        await _dbContext.Evaluations.AddAsync(evaluation, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return evaluation.Id;
    }
}
