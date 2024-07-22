using Evaluations.Application.Common.Exceptions;
using Evaluations.Application.Interfaces;
using Evaluations.Domain;
using MediatR;

namespace Evaluations.Application.Evaluations.Commands.DeleteEvaluation;

public class DeleteEvaluationCommandHandler : IRequestHandler<DeleteEvaluationCommand>
{
    private readonly IEvaluationsDbContext _dbContext;
    public DeleteEvaluationCommandHandler(IEvaluationsDbContext dbContext) =>
        _dbContext = dbContext; 
    public async Task Handle(DeleteEvaluationCommand request, 
        CancellationToken cancellationToken) 
    {
        var entity = await _dbContext.Evaluations
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity != null) 
        {
            _dbContext.Evaluations.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    } 
}
