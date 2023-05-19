using AutoMapper;
using GhostProject.App.Core.Business.Recruiters.Commands.Create;
using GhostProject.App.Core.Business.Recruiters.Dto;
using GhostProject.App.Core.Business.Recruiters.Entities;

namespace GhostProject.App.Core.Business.Recruiters.Mappings;

public class RecruiterMappingProfile : Profile
{
    public RecruiterMappingProfile()
    {
        CreateMap<Recruiter, RecruiterDto>();

        CreateMap<CreateOrUpdateRequiterCommand, Recruiter>();
    }
}
