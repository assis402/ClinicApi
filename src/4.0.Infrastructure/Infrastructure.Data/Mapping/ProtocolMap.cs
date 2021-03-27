using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class ProtocolMap : IEntityTypeConfiguration<Protocol>
    {
        public void Configure(EntityTypeBuilder<Protocol> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(100001,1);

            builder.Property(x => x.ProtocolNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.ActionType).IsRequired();
            builder.Property(x => x.ClinicalUnitId).IsRequired().HasMaxLength(6);
            builder.Property(x => x.UserId).IsRequired().HasMaxLength(6);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.UpdateDate).IsRequired();
            builder.Property(x => x.DeletionDate).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Protocols).HasForeignKey(x => x.ClinicalUnitId);

            builder.ToTable("Protocol");
        }
    }
}