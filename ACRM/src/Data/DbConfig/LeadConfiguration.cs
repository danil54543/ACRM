using ACRM.src.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ACRM.src.Data.DbConfig
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasOne(l => l.Employer)
                .WithMany(e => e.Leads)
                .HasForeignKey(l => l.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Form)
                .WithOne(f => f.Lead)
                .HasForeignKey<Lead>(l => l.FormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(l => l.Resource)
                .WithMany(r => r.Leads)
                .HasForeignKey(l => l.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
