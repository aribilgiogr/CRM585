using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities
{
    public class AppUserRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
