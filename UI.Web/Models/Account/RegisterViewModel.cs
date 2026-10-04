using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "İsim", Prompt = "John")]
        [Required(ErrorMessage = "İsim alanı zorunludur!")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyisim", Prompt = "Doe")]
        [Required(ErrorMessage = "Soyisim alanı zorunludur!")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Eposta Adresi", Prompt = "john.doe@example.com")]
        [Required(ErrorMessage = "Eposta alanı zorunludur!")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = "Parola", Prompt = "Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Parola Onayla", Prompt = "Parola Onayla")]
        [Required(ErrorMessage = "Parola onaylama alanı zorunludur!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar aynı değil!")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
