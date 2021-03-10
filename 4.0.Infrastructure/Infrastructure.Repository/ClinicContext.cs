using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Infrastructure.Repository
{
    public partial class ClinicContext : DbContext
    {
        public DbSet<User> ClinicUnit { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User> Schedule { get; set; }

        public ClinicContext()
        {
        }

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }

        public override int SaveChanges()
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new ClinicUnitMap());
            //modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfiguration(new ScheduleMap());
        }
    }
}
