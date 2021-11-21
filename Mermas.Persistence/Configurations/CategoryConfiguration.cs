using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mermas.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            AuditableEntityConfiguration<Category>.SetProperties(builder);
            SoftDeleteConfiguration<Category>.SetProperties(builder);

            builder.Property(m => m.Title)
                .IsRequired();

            builder.Property(m => m.ProductMinStockQuantity);
        }
    }
}
