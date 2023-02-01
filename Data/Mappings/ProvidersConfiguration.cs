using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ProvidersConfiguration : IEntityTypeConfiguration<Providers>
    {
        public void Configure(EntityTypeBuilder<Providers> builder)
        {
            builder.HasKey(b => b.Code);
            builder.Property(b => b.Description);
            builder.Property(b => b.CNPJ);
        }
    }
}
