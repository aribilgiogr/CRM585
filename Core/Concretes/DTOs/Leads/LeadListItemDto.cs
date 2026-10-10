using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Leads
{
    public record LeadListItemDto(string Id, string Name, string Email, string PhoneNumber, LeadSource Source, string AssignedUserId, string AssignedUserName, LeadStatus Status);
}
