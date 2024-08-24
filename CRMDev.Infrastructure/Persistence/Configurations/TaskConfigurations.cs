using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    public class TaskConfigurations : IEntityTypeConfiguration<Core.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Task> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(t => t.TaskNotes)
                .WithOne()
                .HasForeignKey(t => t.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(t => t.Stage)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StageId);
        }
    }
}
