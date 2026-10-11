using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Enums
{
    public enum LeadSource
    {
        [Display(Name = "Web Sitesi")]
        Website = 1,
        [Display(Name = "Referans")]
        Referral = 2,
        [Display(Name = "Kampanya/Reklam")]
        Campaign = 3,
        [Display(Name = "Fuar")]
        TradeShow = 4,
        [Display(Name = "Sosyal Medya")]
        SocialMedia = 5,
        [Display(Name = "Soğuk Arama")]
        ColdCall = 6,
        [Display(Name = "Ortak Kurum")]
        Partner = 7,
        [Display(Name = "Diğer")]
        Other = 0,
    }
}
