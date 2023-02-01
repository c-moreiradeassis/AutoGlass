using Data.Mappings;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
        public DbSet<Providers> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ProductsConfiguration())
                .ApplyConfiguration(new ProvidersConfiguration());

            base.OnModelCreating(builder);
        }
    }
}