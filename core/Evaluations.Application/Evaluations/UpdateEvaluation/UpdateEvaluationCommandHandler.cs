using MediatR;
using Evaluations.Application.Interfaces;
using Evaluations.Domain;
using Microsoft.EntityFrameworkCore;
using Evaluations.Application.Common.Exceptions;

namespace Evaluations.Application.Evaluations.Commands.UpdateEvaluation;

public class UpdateEvaluationCommandHandler : IRequestHandler<UpdateEvaluationCommand>
{
    private readonly IEvaluationsDbContext _dbContext;
    public UpdateEvaluationCommandHandler(IEvaluationsDbContext dbContext) =>
        _dbContext = dbContext;
    public async Task Handle(UpdateEvaluationCommand request, 
        CancellationToken cancellationToken) 
    {
        var entity = await _dbContext.Evaluations.FirstOrDefaultAsync(evaluation => 
            evaluation.Id == request.Id, cancellationToken);
        if (entity == null || entity.UserId != request.UserId || 
            entity.ProductId != request.ProductId) 
        {
            throw new NotFoundException(nameof(Evaluation), request.Id);
        }
        entity.Value = request.Value;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
