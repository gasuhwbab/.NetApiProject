using MediatR;

namespace Evaluations.Application.Evaluations.Queries.GetUserEvaluations;

public class GetUserEvaluationsQuery : IRequest<ICollection<UserEvaluationsVm>>
{
    public Guid UserId { get; set; }
}
