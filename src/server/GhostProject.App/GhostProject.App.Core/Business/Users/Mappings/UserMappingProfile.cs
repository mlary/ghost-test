using AutoMapper;
using GhostProject.App.Core.Business.Users.Commands.Create;
using GhostProject.App.Core.Business.Users.Commands.Update;
using GhostProject.App.Core.Business.Users.Dto;
using GhostProject.App.Core.Business.Users.Entities;
using GhostProject.App.Core.Business.Users.Primitives;

namespace GhostProject.App.Core.Business.Users.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.RoleId, opt => opt
                .MapFrom(_ => Roles.Employer))
            .ForMember(x => x.NormalizedEmail,
                x => x.MapFrom(y => y.Email.ToUpper()));
        
        CreateMap<UpdateUserCommand, User>()
            .ForMember(x => x.NormalizedEmail,
                x => x.MapFrom(y => y.Email.ToUpper()));
        
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(
                src => (Roles)src.RoleId));
    }
}
