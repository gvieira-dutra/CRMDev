using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMDev.Infrastructure.Persistence.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasMany(c => c.Notes)
                .WithOne(n => n.Contact)
                .HasForeignKey(n => n.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(c => c.FieldOrIndustry)
                .WithMany(f => f.Contacts)
                .HasForeignKey(c => c.FieldOrIndustryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
