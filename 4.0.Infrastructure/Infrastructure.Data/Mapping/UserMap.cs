using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1001,1);

            builder.Property(u => u.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.ClinicUnitId).IsRequired().HasMaxLength(10);
            builder.Property(u => u.CreationDate).IsRequired();
            builder.Property(u => u.UpdateDate).IsRequired();
            builder.Property(u => u.DeletionDate).IsRequired();

            builder.HasMany(u => u.Schedules).WithOne(s => s.User).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.ClinicUnit).WithMany(c => c.Users).HasForeignKey(u => u.ClinicUnitId);

            builder.ToTable("User");
        }
    }
}