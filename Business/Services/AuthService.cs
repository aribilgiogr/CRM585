using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Auth;
using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity;
using Utilities._585.Models;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppUserRole> roleManager;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppUserRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public Task<Reply> ActivateAccountAsync(ActivateAccountDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> ChangePasswordAsync(ChangePasswordDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Reply> LoginAsync(LoginDto model)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Reply.Success();
                }
                else if (result.IsLockedOut)
                {
                    return Reply.Fail("Kullanıcı hesabı kilitlenmiştir! Lütfen yöneticinizle iletişime geçin!");
                }
                else if (result.IsNotAllowed)
                {
                    return Reply.Fail("Bu kullanıcı hesabının giriş yapmaya izni yoktur! Lütfen hesabınızı onaylayın.");
                }
                else if (result.RequiresTwoFactor)
                {
                    return Reply.Fail("İki faktörlü doğrulama zorunludur!");
                }
                else
                {
                    return Reply.Fail("Eposta adresiniz veya şifreniz hatalıdır!");
                }
            }
            catch (Exception ex)
            {
                return Reply.Fail(["Giriş sırasında bilinmeyen bir hata oluştu!", ex.Message]);
            }
        }

        public async Task<Reply> LogoutAsync()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Reply.Success();
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);
            }
        }

        public async Task<Reply> RegisterAsync(RegisterDto model)
        {
            try
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    EmailConfirmed=false // token göndererek bu kısmı true yapacağız.
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, model.Role);
                    await signInManager.SignInAsync(user, false);

                    // token maili gönderme aşaması gelecek

                    return Reply.Success();
                }
                return Reply.Fail(result.Errors.Select(e => e.Description));
            }
            catch (Exception ex)
            {
                return Reply.Fail(["Kayıt sırasında bilinmeyen bir hata oluştu!", ex.Message]);
            }
        }

        public Task<Reply> ResetPasswordAsync(ResetPasswordDto model)
        {
            throw new NotImplementedException();
        }
    }
}
