using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class ResetPasswordViewModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Yeni Parola", Prompt = "Yeni Parola")]
        public string Password { get; set; } = null!;

        [Required, DataType(DataType.Password), Display(Name = "Yeni Parolayı Onayla", Prompt = "Yeni Parolayı Onayla"), Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required, EmailAddress, Display(Name = "E-posta Adresi", Prompt = "E-posta Adresi"), ReadOnly(true)]
        public string Email { get; set; } = null!;

        [Required, Display(Name = "Token"), ReadOnly(true)]
        public string Token { get; set; } = null!;
    }
}
