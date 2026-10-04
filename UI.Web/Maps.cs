using AutoMapper;
using Core.Concretes.DTOs.Auth;
using Core.Concretes.Entities;
using UI.Web.Models.Account;

namespace UI.Web
{
    public class Maps : Profile
    {
        public Maps()
        {
            // ViewModels -> DTOs
            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<RegisterViewModel, RegisterDto>()
                .ForCtorParam("Role", opt => opt.MapFrom(src => "SP"));

            // DTOs -> Entities
            CreateMap<RegisterDto, AppUser>()
               .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
