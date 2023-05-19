using AutoMapper;
using GhostProject.App.Core.Business.Companies.Commands.Create;
using GhostProject.App.Core.Business.Companies.Commands.Update;
using GhostProject.App.Core.Business.Companies.Dto;
using GhostProject.App.Core.Business.Companies.Entities;
using GhostProject.App.Core.Extensions;

namespace GhostProject.App.Core.Business.Companies.Mappings;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<CreateCompanyCommand, Company>()
            .ForMember(dest => dest.CompanyNormalizedName,
                opt => opt.MapFrom(src => src
                    .Name.ToNormalizedCompanyName()));
        CreateMap<UpdateCompanyCommand, Company>()
            .ForMember(dest => dest.CompanyNormalizedName,
                opt => opt.MapFrom(src => src
                    .Name.ToNormalizedCompanyName()));
    }
}
