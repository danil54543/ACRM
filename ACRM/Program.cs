using ACRM.src.BL.Repository;
using ACRM.src.BL.Service;
using ACRM.src.Data;
using ACRM.src.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static ACRM.src.BL.Repository.BranchRepository;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));
        builder.Services.AddIdentity<Employer, IdentityRole<Guid>>(opts =>
        {
            opts.User.RequireUniqueEmail = true;
            opts.Password.RequiredLength = 6;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        builder.Services.AddScoped<IBranchRepository, BranchRepository>();
        builder.Services.AddScoped<IBranchService, BranchService>();

        builder.Services.ConfigureApplicationCookie(opts =>
        {
            opts.Cookie.Name = "crm";
            opts.Cookie.HttpOnly = true;
            opts.LoginPath = "/account/login";
            opts.AccessDeniedPath = "/account/accessdenied";
            opts.SlidingExpiration = true;
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
                pattern: "{controller=Account}/{action=SignIn}/{id?}");
        });


        app.Run();
    }
}