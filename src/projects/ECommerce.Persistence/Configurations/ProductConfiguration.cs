
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ProductId").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Price).HasColumnName("Price").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description").IsRequired();
        builder.Property(x => x.Stock).HasColumnName("Stock").IsRequired();
        builder.Property(x => x.SubCategoryId).HasColumnName("SubCategoryId").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

        builder.HasMany(x => x.ProductTags)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.ProductImages)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
