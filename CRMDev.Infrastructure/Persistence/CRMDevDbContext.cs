using CRMDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRMDev.Infrastructure.Persistence
{
    public class CRMDevDbContext : DbContext
    {
        public CRMDevDbContext(DbContextOptions<CRMDevDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<FieldOrIndustry> FieldOrIndustries { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<CRMDev.Core.Entities.Task> Tasks { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<ContactNote> ContactNotes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    
    }
}
