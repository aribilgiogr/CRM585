using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = [];
    }
}
