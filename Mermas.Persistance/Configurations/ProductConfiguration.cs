using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mermas.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            AuditableEntityConfiguration<Product>.SetProperties(builder);
            SoftDeleteConfiguration<Product>.SetProperties(builder);

            builder.Property(m => m.Title)
                .IsRequired();
            builder.Property(m => m.Description)
                .IsRequired();
            builder.Property(m => m.StockQuantity)
                .IsRequired();
            builder.HasOne(m => m.Category)
                .WithMany(m => m.Products);
            builder.Ignore(m => m.Category);
        }
    }
}
