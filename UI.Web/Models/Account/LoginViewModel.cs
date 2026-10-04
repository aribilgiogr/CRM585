using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Eposta Adresi", Prompt = "john.doe@example.com")]
        [Required(ErrorMessage = "Eposta alanı zorunludur!")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "Parola", Prompt = "Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
