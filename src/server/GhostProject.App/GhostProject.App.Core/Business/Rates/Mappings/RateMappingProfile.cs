using AutoMapper;
using GhostProject.App.Core.Business.Rates.Commands.Create;
using GhostProject.App.Core.Business.Rates.Dto;
using GhostProject.App.Core.Business.Rates.Entities;
using GhostProject.App.Core.Business.Rates.Primitives;

namespace GhostProject.App.Core.Business.Rates.Mappings;

public class RateMappingProfile : Profile
{
    public RateMappingProfile()
    {
        CreateMap<Rate, RateDto>()
            .ForMember(dest => dest.PositionSeniorityLevel,
                opt => opt
                    .MapFrom(src => (PositionSeniorityLevels)src.PositionSeniorityLevel))
            .ForMember(dest => dest.VisitedLinkedInProfile,
                opt => opt
                    .MapFrom(src => (AnswerTypes)src.VisitedLinkedInProfile));
        CreateMap<CreateRateCommand, Rate>()
            .ForMember(dest => dest.PositionSeniorityLevel,
                opt => opt
                    .MapFrom(src => (int)src.PositionSeniorityLevel))
            .ForMember(dest => dest.VisitedLinkedInProfile,
                opt => opt
                    .MapFrom(src => (int)src.VisitedLinkedInProfile));
    }
}
