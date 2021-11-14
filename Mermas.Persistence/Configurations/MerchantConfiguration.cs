using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mermas.Persistence.Configurations
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        private const int MAX_TITLE_LENGTH = 200;
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            AuditableEntityConfiguration<Merchant>.SetProperties(builder);

            builder.Property(m => m.Id);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(MAX_TITLE_LENGTH);

            builder.Ignore(m => m.AllProducts);

            builder.Ignore(m => m.PublishedProducts);

            builder.Ignore(m => m.HiddenProducts);
        }
    }
}
