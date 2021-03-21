using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class ClinicalUnitMap : IEntityTypeConfiguration<ClinicalUnit>
    {
        public void Configure(EntityTypeBuilder<ClinicalUnit> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(u => u.Id).UseIdentityColumn(100001,1);

            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(250);
            builder.Property(c => c.TaxNumber).IsRequired().HasMaxLength(14);
            builder.Property(c => c.CreationDate).IsRequired();
            builder.Property(c => c.UpdateDate).IsRequired();
            builder.Property(c => c.DeletionDate).IsRequired();

            builder.HasMany(c => c.Users).WithOne(u => u.ClinicalUnit).OnDelete(DeleteBehavior.Restrict);
            
            builder.ToTable("ClinicalUnit");
        }
    }
}