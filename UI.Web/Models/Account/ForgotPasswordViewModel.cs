using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "Eposta Adresi", Prompt = "john.doe@example.com")]
        [Required(ErrorMessage = "Eposta alanı zorunludur!")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "Eposta Adresi Onayla", Prompt = "john.doe@example.com")]
        [Required(ErrorMessage = "Eposta onaylama alanı zorunludur!")]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Eposta adresleri aynı değil!")]
        public string ConfirmEmail { get; set; } = null!;
    }
}
