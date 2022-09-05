using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain;

namespace Products.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.Name).IsRequired().HasMaxLength(250);
            builder.OwnsMany(b => b.Properties, pp =>
            {
                pp.WithOwner().HasForeignKey(x => x.ProductId);
                pp.Has
            });
        }
    }
}
