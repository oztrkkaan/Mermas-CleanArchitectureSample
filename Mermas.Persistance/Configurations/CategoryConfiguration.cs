using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mermas.Persistance.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m => m.Title)
                .IsRequired();
            builder.Property(m => m.IsDeleted);
            builder.Property(m => m.DeletionDate);
            builder.Ignore(m => m.Products);

            AuditableEntityConfiguration<Category>.SetProperties(builder);
            SoftDeleteConfiguration<Category>.SetProperties(builder);
        }
    }
}
