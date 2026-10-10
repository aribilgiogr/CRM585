using AutoMapper;
using Core.Concretes.DTOs.Auth;
using Core.Concretes.DTOs.Leads;
using Core.Concretes.Entities;
using Core.Concretes.Enums;
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

            CreateMap<ResetPasswordViewModel, ResetPasswordDto>();

            // DTOs -> Entities
            CreateMap<RegisterDto, AppUser>()
               .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<CreateLeadDto, Lead>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => LeadStatus.New));

            // Entities -> DTOs
            CreateMap<Lead, LeadListItemDto>()
                .ForCtorParam("AssignedUserName", opt => opt.MapFrom(src => src.AssignedUser != null ? $"{src.AssignedUser.FirstName} {src.AssignedUser.LastName}" : null));
        }
    }
}
