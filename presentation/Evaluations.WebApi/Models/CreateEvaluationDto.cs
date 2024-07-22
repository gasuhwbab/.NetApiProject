using AutoMapper;
using Evaluations.Application.Common.Mappings;
using Evaluations.Application.Evaluations.Commands.CreateEvaluation;

namespace Evaluations.WebApi.Models;

public class CreateEvaluationDto : IMapWith<CreateEvaluationCommand>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Value { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateEvaluationDto, CreateEvaluationCommand>()
            .ForMember(command => command.ProductId,
                opt => opt.MapFrom(dto => dto.ProductId))
            .ForMember(command => command.UserId,
                opt => opt.MapFrom(dto => dto.UserId))
            .ForMember(command => command.Value,
                opt => opt.MapFrom(dto => dto.Value));
    }
}
