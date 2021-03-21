using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1001,1);

            builder.Property(s => s.ScheduleDate).IsRequired();
            builder.Property(s => s.UserId).IsRequired();
            builder.Property(s => s.CreationDate).IsRequired();
            builder.Property(s => s.UpdateDate).IsRequired();
            builder.Property(s => s.DeletionDate).IsRequired();

            builder.HasOne(s => s.User).WithMany(c => c.Schedules).HasForeignKey(u => u.UserId);
            builder.HasOne(s => s.ClinicalUnit).WithMany(c => c.Schedules).HasForeignKey(u => u.ClinicalUnitId);

            builder.ToTable("Schedule");
        }
    }
}