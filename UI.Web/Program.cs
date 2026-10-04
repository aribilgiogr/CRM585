using Business;
using Core.Concretes.Entities;
using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UI.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<Maps>());

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddBusinessServices(builder.Configuration);

var app = builder.Build();

// Açılışta varsa veritabanı migrasyonlarını otomatik uygula (Update-Database). Ayrıca önceden tanımlanmış olması gereken iki rolü (ADM ve SP) yoksa oluştur.
using (var scope = app.Services.CreateScope())
{
    // Update-Database uygulanır.
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    // Roller kontrol edilir, eğer yoksa oluşturulur.
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppUserRole>>();
    var roles = builder.Configuration.GetSection("BaseRoles").Get<string[]>();
    if (roles != null)
    {
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new AppUserRole { Name = role });
            }
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

