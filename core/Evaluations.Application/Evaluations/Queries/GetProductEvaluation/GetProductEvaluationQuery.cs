using MediatR;

namespace Evaluations.Application.Evaluations.Queries.GetProductEvaluation;

public class GetProductEvaluationQuery : IRequest<ICollection<ProductEvaluationVm>>
{
    public Guid ProductId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
