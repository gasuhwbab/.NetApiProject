using MediatR;

namespace Evaluations.Application.Evaluations.Commands.CreateEvaluation;

public class CreateEvaluationCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Value { get; set; }
}
