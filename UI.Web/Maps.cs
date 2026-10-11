using AutoMapper;
using Core.Concretes.DTOs.Activities;
using Core.Concretes.DTOs.Auth;
using Core.Concretes.DTOs.Customers;
using Core.Concretes.DTOs.Leads;
using Core.Concretes.DTOs.Opportunities;
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

            CreateMap<CreateCustomerDto, Customer>()
                .ForMember("Status", opt => opt.MapFrom(src => CustomerStatus.Potential));

            // Entities -> DTOs
            CreateMap<Lead, LeadListItemDto>()
                .ForCtorParam("AssignedUserName", opt => opt.MapFrom(src => src.AssignedUser != null ? $"{src.AssignedUser.FirstName} {src.AssignedUser.LastName}" : null));

            CreateMap<Activity, ActivityListDto>()
                .ForMember(dest => dest.AssignedUserName, opt => opt.MapFrom(src => src.AssignedUser != null ? $"{src.AssignedUser.FirstName} {src.AssignedUser.LastName}" : null));

            CreateMap<Opportunity, OpportunityListDto>();

            CreateMap<Lead, LeadDetailDto>()
                .ForMember(dest => dest.AssignedUserName, opt => opt.MapFrom(src => src.AssignedUser != null ? $"{src.AssignedUser.FirstName} {src.AssignedUser.LastName}" : null))
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt ?? src.CreatedAt));

            CreateMap<Customer, CustomerListItemDto>()
                .ForCtorParam("AssignedUserName", opt => opt.MapFrom(src => src.AssignedUser != null ? $"{src.AssignedUser.FirstName} {src.AssignedUser.LastName}" : null))
                .ForCtorParam("ActivityCount", opt => opt.MapFrom(src => src.Activities.Count))
                .ForCtorParam("OpportunityCount", opt => opt.MapFrom(src => src.Opportunities.Count));

            CreateMap<Customer, CustomerDetailDto>()
                .ForMember(dest => dest.AssignedUserName, opt => opt.MapFrom(src => src.AssignedUser != null ? $"{src.AssignedUser.FirstName} {src.AssignedUser.LastName}" : null))
                .ForMember(dest => dest.LeadActivities, opt => opt.MapFrom(src => src.ConvertedFromLead.Activities))
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt ?? src.CreatedAt))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ConvertedFromLead.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ConvertedFromLead.PhoneNumber))
                .ForMember(dest => dest.LeadNotes, opt => opt.MapFrom(src => src.ConvertedFromLead.Notes))
                .ForMember(dest => dest.LeadSource, opt => opt.MapFrom(src => src.ConvertedFromLead.Source));

        }
    }
}
