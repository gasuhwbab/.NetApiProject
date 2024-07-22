using AutoMapper;
using Evaluations.Application.Common.Mappings;
using Evaluations.Domain;

namespace Evaluations.Application.Evaluations.Queries.GetAverageProductsEvaluation;

public class AverageProductEvaluationVm
{
    public Guid ProductId { get; set; }
    public double AverageValue { get; set; }
}
