using ACRM.src.Data.DbConfig;
using ACRM.src.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ACRM.src.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Employer, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Resource> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Id = Guid.Parse("44546e06-8719-4ad8-b88a-f271ae9d6eab"),
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<Employer>().HasData(new Employer
            {
                Id = Guid.Parse("3b62472e-4f66-49fa-a20f-e7685b9565d8"),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<Employer>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("44546e06-8719-4ad8-b88a-f271ae9d6eab"),
                UserId = Guid.Parse("3b62472e-4f66-49fa-a20f-e7685b9565d8")
            });
            modelBuilder.ApplyConfiguration(new FormConfiguration());
            modelBuilder.ApplyConfiguration(new LeadConfiguration());

        }
    }
}
