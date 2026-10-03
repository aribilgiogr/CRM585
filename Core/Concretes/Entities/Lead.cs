using Core.Abstracts.Bases;
using Core.Concretes.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    public class Lead : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Notes { get; set; }

        public string? ConvertedCustomerId { get; set; }
        public virtual Customer? ConvertedCustomer { get; set; }

        public DateTime? ConvertedAt { get; set; }

        public string? AssignedUserId { get; set; }
        public virtual AppUser? AssignedUser { get; set; }

        public LeadSource Source { get; set; }
        public LeadStatus Status { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } = [];
    }
}
