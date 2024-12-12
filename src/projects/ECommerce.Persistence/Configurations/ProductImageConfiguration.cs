
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ProductImageId").IsRequired();
        builder.Property(x => x.Url).HasColumnName("Url").IsRequired();
        builder.Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductImages)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
