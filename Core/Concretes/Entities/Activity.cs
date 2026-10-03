using Core.Abstracts.Bases;
using Core.Concretes.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    public class Activity : BaseEntity
    {
        public string Subject { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }

        public string? RelatedCustomerId { get; set; }
        public virtual Customer? RelatedCustomer { get; set; }

        public string? RelatedLeadId { get; set; }
        public virtual Lead? RelatedLead { get; set; }

        public string? RelatedOpportunityId { get; set; }
        public virtual Opportunity? RelatedOpportunity { get; set; }

        public string? AssignedUserId { get; set; }
        public virtual AppUser? AssignedUser { get; set; }

        public ActivityType Type { get; set; }
    }
}
