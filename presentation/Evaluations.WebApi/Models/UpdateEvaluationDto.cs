using AutoMapper;
using Evaluations.Application.Common.Mappings;
using Evaluations.Application.Evaluations.Commands.UpdateEvaluation;

namespace Evaluations.WebApi.Models;

public class UpdateEvaluationDto : IMapWith<UpdateEvaluationCommand>
{
    public Guid Id { get; set; }
    public int Value { get; set; }

    public void Mapping(Profile profile) 
    {
        profile.CreateMap<UpdateEvaluationDto, UpdateEvaluationCommand>()
            .ForMember(command => command.Value,
                opt => opt.MapFrom(dto => dto.Value));
    }
}
