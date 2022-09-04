using Microsoft.EntityFrameworkCore;
using Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Interfaces
{
    public interface IProductsDbContext
    {
        public DbSet<Product> Products { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
