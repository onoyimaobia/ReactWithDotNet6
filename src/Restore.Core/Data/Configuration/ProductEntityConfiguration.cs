
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restore.Core.Models;

namespace Restore.Core.Data.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(38, 2)");
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasMaxLength(350)
                .IsRequired();
            builder.Property(e => e.QuantityInStock)
                .IsRequired();
            builder.Property(e => e.PictureUrl)
                .IsRequired();
            builder.Property(e => e.Brand)
                .IsRequired();
            builder.Property(e => e.Type)
                .IsRequired();
            
        }
    }
}