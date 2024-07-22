using AutoMapper;
using Evaluations.Application.Common.Mappings;
using Evaluations.Domain;

namespace Evaluations.Application.Evaluations.Queries.GetProductEvaluation;

public class ProductEvaluationVm : IMapWith<Evaluation>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Value { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<Evaluation, ProductEvaluationVm>()
            .ForMember(evaluationVm => evaluationVm.UserId,
                opt => opt.MapFrom(evaluation => evaluation.UserId))
            .ForMember(evaluationVm => evaluationVm.Value,
                opt => opt.MapFrom(evaluation => evaluation.Value));
    }

}
