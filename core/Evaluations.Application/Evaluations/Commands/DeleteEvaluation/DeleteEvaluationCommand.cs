using MediatR;

namespace Evaluations.Application.Evaluations.Commands.DeleteEvaluation;

public class DeleteEvaluationCommand : IRequest
{
    public Guid Id { get; set; }
}
