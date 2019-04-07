using AutoMapper;
using Waves.Domain.Identity;
using Waves.Domain.Models;
using Waves.Domain.Models.User;
using Waves.Entities.Models;
using Waves.Entities.Models.Isle;
using Waves.Entities.Models.Options;
using Waves.Entities.Models.Oscillator;
using Waves.Entities.Models.User;
using Waves.Services.Extensions;
using Waves.Services.Services.Models.User;

namespace Waves.Services.MapProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<AppRole, AppRoleDTO>().ReverseMap();
            CreateMap<AppUser, AppUserDTO>().ReverseMap();

            CreateMap<Isle, IsleDTO>().ReverseMap();
            CreateMap<Options, OptionsDTO>().ReverseMap();
            CreateMap<Oscillator, OscillatorDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Sea, SeaDTO>().ReverseMap();

            CreateMap<CreateUserModel, AppUser>()
                .IgnoreAllUnmapped()
                .ForMember(u => u.RoleId, m => m.MapFrom(u => u.RoleId))
                //.ForMember(u => u.FirstName, m => m.MapFrom(u => u.FirstName))
                //.ForMember(u => u.LastName, m => m.MapFrom(u => u.LastName))
                .ForMember(u => u.Email, m => m.MapFrom(u => u.Email))
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Email));

            CreateMap<UpdateUserModel, AppUser>()
                .IgnoreAllUnmapped()
                .ForMember(u => u.RoleId, m => m.MapFrom(u => u.RoleId))
                .ForMember(u => u.FirstName, m => m.MapFrom(u => u.FirstName))
                .ForMember(u => u.LastName, m => m.MapFrom(u => u.LastName))
                .ForMember(u => u.Email, m => m.MapFrom(u => u.Email))
                .ForMember(u => u.UserName, m => m.MapFrom(u => u.Email))
                .ForMember(u => u.IsActive, m => m.MapFrom(u => u.IsActive));
        }
    }
}
