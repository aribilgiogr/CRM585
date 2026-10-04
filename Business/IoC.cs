using Business.Services;
using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities._585.Extensions;

namespace Business
{
    public static class IoC
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("data")));

            services.AddIdentity<AppUser, AppUserRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddUnitOfWork<AppDbContext>();

            services.AddSmtpEmailSender(configuration);

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
