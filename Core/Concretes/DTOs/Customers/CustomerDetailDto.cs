using Core.Concretes.DTOs.Activities;
using Core.Concretes.DTOs.Opportunities;
using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Customers
{
    public class CustomerDetailDto
    {
        public string Id { get; set; } = null!;
        public DateTime LastUpdatedAt { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? LeadNotes { get; set; }
        public LeadSource LeadSource { get; set; }
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool Individual { get; set; }
        public CustomerStatus Status { get; set; }
        public string? AssignedUserId { get; set; }
        public string? AssignedUserName { get; set; }
        public IEnumerable<ActivityListDto> LeadActivities { get; set; } = [];
        public IEnumerable<ActivityListDto> Activities { get; set; } = [];
        public virtual ICollection<OpportunityListDto> Opportunities { get; set; } = [];
    }
}
