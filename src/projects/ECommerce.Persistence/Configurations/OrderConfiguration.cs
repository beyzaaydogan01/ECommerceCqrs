
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("OrderId").IsRequired();
            builder.Property(x => x.Total).HasColumnName("Total").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

