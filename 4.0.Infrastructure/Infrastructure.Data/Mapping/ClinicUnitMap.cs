using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class ClinicUnitMap : IEntityTypeConfiguration<ClinicUnit>
    {
        public void Configure(EntityTypeBuilder<ClinicUnit> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1001,1);

            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(250);
            builder.Property(c => c.Login).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Password).IsRequired();
            builder.Property(c => c.CreationDate).IsRequired();
            builder.Property(c => c.UpdateDate).IsRequired();
            builder.Property(c => c.DeletionDate).IsRequired();

            builder.HasMany(c => c.Users).WithOne(u => u.ClinicUnit).OnDelete(DeleteBehavior.Restrict);
            
            builder.ToTable("ClinicUnit");
        }
    }
}