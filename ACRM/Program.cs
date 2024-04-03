using ACRM.src.Data;
using ACRM.src.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");

        builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));
        builder.Services.AddIdentity<Employer, IdentityRole>(opts =>
        {
            opts.User.RequireUniqueEmail = true;
            opts.Password.RequiredLength = 6;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "crm";
            options.Cookie.HttpOnly = true;
            options.LoginPath = "/account/login";
            options.AccessDeniedPath = "/account/accessdenied";
            options.SlidingExpiration = true;
        });
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();//TODO
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
        });


        app.Run();
    }
}