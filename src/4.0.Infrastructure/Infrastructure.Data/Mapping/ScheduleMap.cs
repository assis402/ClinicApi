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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(100001,1);

            builder.Property(x => x.ScheduleDate).IsRequired();
            builder.Property(x => x.PatientId).IsRequired().HasMaxLength(6);
            builder.Property(x => x.ClinicalUnitId).IsRequired().HasMaxLength(6);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.DeletionDate).IsRequired();

            builder.HasOne(x => x.Patient).WithMany(x => x.Schedules).HasForeignKey(x => x.PatientId);
            //builder.HasOne(x => x.ClinicalUnit).WithMany(x => x.Schedules).HasForeignKey(x => x.ClinicalUnitId);

            builder.ToTable("Schedule");
        }
    }
}