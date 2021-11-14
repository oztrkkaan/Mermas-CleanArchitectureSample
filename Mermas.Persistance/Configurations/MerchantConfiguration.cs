using Mermas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mermas.Persistance.Configurations
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Category>
    {
        private const int MAX_TITLE_LENGTH = 200;
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(MAX_TITLE_LENGTH);
        }
    }
}
