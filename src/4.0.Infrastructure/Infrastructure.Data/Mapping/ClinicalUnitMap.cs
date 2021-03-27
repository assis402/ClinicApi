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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(100001,1);

            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.TaxNumber).IsRequired().HasMaxLength(14);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.DeletionDate).IsRequired();

            //builder.HasMany(x => x.Users).WithOne(x => x.ClinicalUnit).OnDelete(DeleteBehavior.Restrict);
            
            builder.ToTable("ClinicalUnit");
        }
    }
}