using Evaluations.Application.Interfaces;
using Evaluations.Domain;

namespace Evaluations.Application;

public class ChangeEvaluationCommandHandler
{
    private readonly IEvaluationsDbContext _dbContext;
    public ChangeEvaluationCommandHandler(IEvaluationsDbContext dbContext) => 
        _dbContext = dbContext; 
    public async Task<Guid> Handle(ChangeEvaluationCommand request, 
        CancellationToken cancellationToken)
    {
        var evaluation = new Evaluation
        {
            Value = request.Value,
            Id = request.Id
        };
        _dbContext.Evaluations.Update(evaluation);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return evaluation.Id;
    }   
}
