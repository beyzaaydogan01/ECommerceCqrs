
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("CategoryId").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder
            .HasMany(x => x.SubCategories)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
