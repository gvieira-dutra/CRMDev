using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    public class TaskNoteConfigurations : IEntityTypeConfiguration<TaskNote>
    {
        public void Configure(EntityTypeBuilder<TaskNote> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasOne(t => t.Task)
                .WithMany(t => t.TaskNotes)
                .HasForeignKey(t => t.TaskId);
        }
    }
}
