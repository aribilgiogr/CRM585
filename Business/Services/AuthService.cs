using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs.Auth;
using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Text;
using Utilities._585.Extensions;
using Utilities._585.Models;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppUserRole> roleManager;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppUserRole> roleManager, IMapper mapper, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.emailSender = emailSender;
        }

        public Task<Reply> ActivateAccountAsync(ActivateAccountDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Reply> ChangePasswordAsync(ChangePasswordDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<Reply> ForgotPasswordAsync(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null) return Reply.Fail("Kullanıcı bulunamadı!");

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var validToken = token.Base64UrlEncode();
                var message = $"Parolanızı sıfırlamak için <a href='https://localhost:7196/account/resetpassword?email={email}&token={validToken}'>tıklayız</a>.";
                try
                {
                    await emailSender.SendEmailAsync(email, "Parola Sıfırlama", message);
                }
                catch (Exception ex)
                {
                    return Reply.Fail(ex.Message);
                }
                return Reply.Success();
            }
            catch (Exception ex)
            {
                return Reply.Fail(["Şifre hatırlatma aşamasında beklenmeyen bir hata oluştu!", ex.Message]);
            }
        }

        public bool IsSignedIn(ClaimsPrincipal User) => signInManager.IsSignedIn(User);

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
                /*
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    EmailConfirmed=false // token göndererek bu kısmı true yapacağız.
                };
                */
                var user = mapper.Map<AppUser>(model);
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
