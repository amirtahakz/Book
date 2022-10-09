using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.SiteEntities;

namespace Infrastructure.Persistent.Ef.SiteEntities;

internal class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
{
    public void Configure(EntityTypeBuilder<ShippingMethod> builder)
    {
        builder.Property(b => b.Title)
            .HasMaxLength(120).IsRequired();
    }
}