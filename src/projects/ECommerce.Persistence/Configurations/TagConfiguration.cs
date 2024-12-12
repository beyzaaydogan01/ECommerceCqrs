
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("TagId").IsRequired();
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedTime");

        builder.HasMany(x => x.ProductTags)
            .WithOne(x => x.Tag)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
