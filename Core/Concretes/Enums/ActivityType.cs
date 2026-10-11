using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Enums
{
    public enum ActivityType
    {
        [Display(Name = "Arama")]
        Call = 1,
        [Display(Name = "E-posta")]
        Email = 2,
        [Display(Name = "Toplantı")]
        Meeting = 3,
        [Display(Name = "Görev")]
        Task = 4,
        [Display(Name = "Not")]
        Note = 5,
        [Display(Name = "Örnek Gösterim")]
        Demo = 6,
        [Display(Name = "Takip Araması")]
        FollowUp = 7
    }
}
