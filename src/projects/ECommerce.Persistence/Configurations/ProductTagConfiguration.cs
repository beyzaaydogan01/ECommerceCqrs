
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.ToTable("ProductTags").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ProductTag").IsRequired();
        builder.Property(x => x.TagId).HasColumnName("TagId").IsRequired();
        builder.Property(x => x.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
