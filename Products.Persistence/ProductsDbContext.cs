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
            SeedInitialData(builder);
            base.OnModelCreating(builder);
        }

        private void SeedInitialData(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = Guid.Parse("d31eeac2-6174-4beb-99b5-7d422e9e2b57"),
                        Name = "Fort 12",
                        Description = "The Fort-12 is a semi-automatic pistol which was designed in the late 1990s by Ukrainian firearms designer RPC Fort.",
                        ImagePath = "https://uprom.info/wp-content/uploads/2018/01/post-1138-0-93874000-1487585663.jpg",
                        Price = 8000,
                        Properties = new List<ProductProperty>
                        {
                            new ProductProperty
                            {
                                OrderNumber = 1,
                                Name = "Weight",
                                Value = "950g"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 2,
                                Name = "Cartridge",
                                Value = "9x18"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 3,
                                Name = "Feed system",
                                Value = "12 Rounds"
                            },
                        },
                        IsActive = true,
                        CreatedAt = DateTime.Today,
                        CreatedBy = Guid.NewGuid()
                    },
                    new Product
                    {
                        Id = Guid.Parse("17b50e4a-1684-4fa1-ad62-522194127aca"),
                        Name = "Colt M1911",
                        Description = "The M1911, also known as Colt 1911 or Colt Government, is a single-action, recoil-operated, semi-automatic pistol chambered for the .45 ACP cartridge. The pistol's formal U.S. military designation as of 1940 was Automatic Pistol, Caliber .45, M1911 for the original model adopted in March 1911, and Automatic Pistol, Caliber .45, M1911A1 for the improved M1911A1 model which entered service in 1926. The designation changed to Pistol, Caliber .45, Automatic, M1911A1 in the Vietnam War era.",
                        ImagePath = "https://image.ceneostatic.pl/data/products/61704732/i-cybergun-pistolet-gbb-colt-1911-100th-anniversary-grey-180532.jpg",
                        Price = 15000,
                        Properties = new List<ProductProperty>
                        {
                            new ProductProperty
                            {
                                OrderNumber = 1,
                                Name = "Weight",
                                Value = "1105g"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 2,
                                Name = "Cartridge",
                                Value = ".45 ACP"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 3,
                                Name = "Feed system",
                                Value = "7 Rounds"
                            },
                        },
                        IsActive = true,
                        CreatedAt = DateTime.Today,
                        CreatedBy = Guid.NewGuid()
                    },
                    new Product
                    {
                        Id = Guid.Parse("b1480c40-64f4-472a-a133-a1e5e3384ac6"),
                        Name = "Glock 17",
                        Description = "Glock is a brand of polymer-framed, short recoil-operated, locked-breech semi-automatic pistols designed and produced by Austrian manufacturer Glock Ges.m.b.H. The firearm entered Austrian military and police service by 1982 after it was the top performer in reliability and safety tests.",
                        ImagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Glock_17_%286825676904%29.jpg/1200px-Glock_17_%286825676904%29.jpg",
                        Price = 10000,
                        Properties = new List<ProductProperty>
                        {
                            new ProductProperty
                            {   
                                OrderNumber = 1,
                                Name = "Weight",
                                Value = "905g"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 2,
                                Name = "Cartridge",
                                Value = "9x19"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 3,
                                Name = "Feed system",
                                Value = "17 Rounds"
                            },
                        },
                        IsActive = true,
                        CreatedAt = DateTime.Today,
                        CreatedBy = Guid.NewGuid()
                    },
                    new Product
                    {
                        Id = Guid.Parse("0f4b782e-441d-49d7-98d3-2a1342b6a05b"),
                        Name = "Beretta 92",
                        Description = "The Beretta 92 is a series of semi-automatic pistols designed and manufactured by Beretta of Italy. The Beretta 92 was designed in 1975, and production began in 1976. Many variants in several different calibers continue to be used to the present. The United States military replaced the .45 ACP M1911A1 pistol in 1985 with the Beretta 92FS, designated as the M9.",
                        ImagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/M9-pistolet.jpg/300px-M9-pistolet.jpg",
                        Price = 12000,
                        Properties = new List<ProductProperty>
                        {
                            new ProductProperty
                            {
                                OrderNumber = 1,
                                Name = "Weight",
                                Value = "950g"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 2,
                                Name = "Cartridge",
                                Value = "9x19"
                            },
                            new ProductProperty
                            {
                                OrderNumber = 3,
                                Name = "Feed system",
                                Value = "15 Rounds"
                            },
                        },
                        IsActive = true,
                        CreatedAt = DateTime.Today,
                        CreatedBy = Guid.NewGuid()
                    });
        }
    }
}
