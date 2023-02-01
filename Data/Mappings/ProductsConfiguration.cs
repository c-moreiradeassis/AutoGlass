using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(b => b.Code);
            builder.Property(b => b.Description);
            builder.Property(b => b.Situation);
            builder.Property(b => b.ManufactureDate);
            builder.Property(b => b.ValidityDate);
            builder.HasOne(p => p.Providers).WithMany(b => b.Products).HasForeignKey(p => p.CodeProvider);
        }
    }
}
