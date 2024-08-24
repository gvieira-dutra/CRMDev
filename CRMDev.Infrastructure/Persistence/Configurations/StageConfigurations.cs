using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    public class StageConfigurations : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(s => s.Tasks)
                .WithOne(t => t.Stage)
                .HasForeignKey(t => t.StageId);

            builder
                .HasOne(s => s.Opportunity)
                .WithMany(o => o.Stages)
                .HasForeignKey(s => s.OpportunityId);
        }
    }
}
