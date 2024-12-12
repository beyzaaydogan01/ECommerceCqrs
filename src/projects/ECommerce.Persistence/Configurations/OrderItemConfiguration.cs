
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("OrderItemId").IsRequired();
        builder.Property(x => x.Count).HasColumnName("Count").IsRequired();
        builder.Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(x => x.OrderId).HasColumnName("OrderId").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
