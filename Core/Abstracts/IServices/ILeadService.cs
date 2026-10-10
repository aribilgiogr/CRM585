using Core.Concretes.DTOs.Leads;
using Core.Concretes.Enums;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Utilities._585.Models;

namespace Core.Abstracts.IServices
{
    public interface ILeadService
    {
        IEnumerable<LeadListItemDto> GetLeads(ClaimsPrincipal user);
        Task<Reply> CreateAsync(CreateLeadDto model);
        Task<Reply> ImportFromFileAsync(IFormFile file);
        Task<Reply> AssignLeadAsync(string leadId, ClaimsPrincipal user);
        Task<Reply> AddActivityAsync(ActivityType type, string leadId, ClaimsPrincipal user);
    }
}
