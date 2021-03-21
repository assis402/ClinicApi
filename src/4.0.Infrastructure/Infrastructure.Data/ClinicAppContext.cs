using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Data.Mapping;

namespace Infrastructure.Data
{
    public partial class ClinicAppContext : DbContext
    {
        public DbSet<User> ClinicalUnit { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User> Schedule { get; set; }

        public ClinicAppContext()
        {
        }

        public ClinicAppContext(DbContextOptions options) : base(options)
        {
        }

        /*public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateDate").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClinicalUnitMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ScheduleMap());
        }

        
    }
}
