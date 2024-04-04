using ACRM.src.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ACRM.src.Data.DbConfig
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder
        .HasOne(f => f.Lead)
        .WithOne(l => l.Form)
        .HasForeignKey<Lead>(l => l.FormId);


        }
    }

}
