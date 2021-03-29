using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class CompanyProfileMap : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(100001,1);

            builder.Property(x => x.TaxNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ClinicalUnitId).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.DeletionDate).IsRequired();

            //builder.HasOne(x => x.ClinicalUnit).WithMany(x => x.Users).HasForeignKey(x => x.ClinicalUnitId);

            builder.ToTable("User");
        }
    }
}