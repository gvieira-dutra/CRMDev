using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    public class OpportunityConfigurations : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(o => o.Stages)
                .WithOne()
                .HasForeignKey(s => s.OpportunityId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
