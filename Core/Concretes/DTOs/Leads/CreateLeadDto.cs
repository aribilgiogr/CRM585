using Core.Concretes.Enums;

namespace Core.Concretes.DTOs.Leads
{
    //public record CreateLeadDto(string Name, string Email, string PhoneNumber, string? Notes, LeadSource Source);
    public class CreateLeadDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Notes { get; set; }
        public LeadSource Source { get; set; }
    }
}
