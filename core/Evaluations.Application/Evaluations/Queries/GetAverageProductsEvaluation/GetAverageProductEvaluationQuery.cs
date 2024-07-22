using MediatR;

namespace Evaluations.Application.Evaluations.Queries.GetAverageProductsEvaluation;

public class GetAverageProductsEvaluationQuery : IRequest<ICollection<AverageProductEvaluationVm>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set;} = 10;
}
