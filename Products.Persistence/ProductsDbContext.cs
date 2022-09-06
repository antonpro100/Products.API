using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Domain;
using Products.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Persistence
{
    public class ProductsDbContext : DbContext, IProductsDbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) :
            base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
