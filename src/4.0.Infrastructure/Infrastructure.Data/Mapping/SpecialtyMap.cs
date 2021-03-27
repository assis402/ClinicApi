using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class SpecialtyMap : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(100001,1);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ClinicalUnitId).IsRequired().HasMaxLength(6);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.DeletionDate).IsRequired();

            builder.ToTable("Specialist");
        }
    }
}