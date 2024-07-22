using AutoMapper;
using Evaluations.Application.Common.Mappings;
using Evaluations.Domain;

namespace Evaluations.Application.Evaluations.Queries.GetUserEvaluations;

public class UserEvaluationsVm : IMapWith<Evaluation>
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public void Mapping(Profile profile) 
    {
        profile.CreateMap<Evaluation, UserEvaluationsVm>()
            .ForMember(evaluationVm => evaluationVm.Value,
                opt => opt.MapFrom(evaluation => evaluation.Value));
    }
}
