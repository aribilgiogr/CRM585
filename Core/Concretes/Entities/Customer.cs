using Core.Abstracts.Bases;
using Core.Concretes.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public bool Individual { get; set; }
        public CustomerStatus Status { get; set; }


        [ForeignKey(nameof(AssignedUser))]
        public string? AssignedUserId { get; set; }
        public virtual AppUser? AssignedUser { get; set; }
    }
}
