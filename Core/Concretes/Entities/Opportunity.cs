using Core.Abstracts.Bases;
using Core.Concretes.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    public class Opportunity : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public string Currency { get; set; } = null!;
        public DateTime? ExpectedCloseDate { get; set; }
        public DateTime? ActualCloseDate { get; set; }


        [ForeignKey(nameof(AssignedUser))]
        public string? AssignedUserId { get; set; }
        public virtual AppUser? AssignedUser { get; set; }


        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;

        public OpportunityStage Stage { get; set; }
        public OpportunityStatus Status { get; set; }
    }
}
