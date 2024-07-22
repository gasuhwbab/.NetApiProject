using MediatR;

namespace Evaluations.Application.Evaluations.Commands.UpdateEvaluation;

public class UpdateEvaluationCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Value { get; set; }
}
