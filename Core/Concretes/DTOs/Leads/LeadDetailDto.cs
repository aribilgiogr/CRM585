using Core.Concretes.DTOs.Activities;
using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Leads
{
    public class LeadDetailDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Notes { get; set; }
        public LeadSource Source { get; set; }
        public string? AssignedUserId { get; set; }
        public string? AssignedUserName { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime? ConvertedAt { get; set; }
        public string? ConvertedCustomerId { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public IEnumerable<ActivityListDto> Activities { get; set; } = [];
    }
}
