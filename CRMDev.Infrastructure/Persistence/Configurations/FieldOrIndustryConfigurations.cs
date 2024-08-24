using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    internal class FieldOrIndustryConfigurations : IEntityTypeConfiguration<FieldOrIndustry>
    {
        public void Configure(EntityTypeBuilder<FieldOrIndustry> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(f => f.Contacts)
                .WithOne(c => c.FieldOrIndustry);
        }
    }
}
