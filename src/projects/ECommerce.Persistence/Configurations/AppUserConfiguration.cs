
using Core.Security.Entities;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }

}