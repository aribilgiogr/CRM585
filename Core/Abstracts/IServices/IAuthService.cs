using Core.Concretes.DTOs.Auth;
using Utilities._585.Models;

namespace Core.Abstracts.IServices
{
    public interface IAuthService
    {
        Task<Reply> LoginAsync(LoginDto model);
        Task<Reply> RegisterAsync(RegisterDto model);
        Task<Reply> LogoutAsync();
        Task<Reply> ForgotPasswordAsync(string email);
        Task<Reply> ResetPasswordAsync(ResetPasswordDto model);
        Task<Reply> ChangePasswordAsync(ChangePasswordDto model);
        Task<Reply> ActivateAccountAsync(ActivateAccountDto model);
    }
}
