using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Enums
{
    public enum LeadStatus
    {
        [Display(Name ="Yeni")]
        New,
        [Display(Name = "İletişime Geçildi")]
        Contacted,
        [Display(Name = "Nitelikli Olduğu Onaylandı")]
        Qualified,
        [Display(Name = "Teklif Verildi")]
        Proposal,
        [Display(Name = "Müzakere Aşamasında")]
        Negotiation,
        [Display(Name = "Dönüştürüldü")]
        Converted,
        [Display(Name = "Kaybedildi")]
        Lost
    }
}
