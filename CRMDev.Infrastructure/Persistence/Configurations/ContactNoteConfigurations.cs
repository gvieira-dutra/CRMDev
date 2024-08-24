using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    public class ContactNoteConfigurations : IEntityTypeConfiguration<ContactNote>
    {
        public void Configure(EntityTypeBuilder<ContactNote> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasOne(t => t.Contact)
                .WithMany(c => c.Notes)
                .HasForeignKey(t => t.ContactId);
        }
    }
}
