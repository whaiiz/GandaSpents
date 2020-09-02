using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<ProductType>()
                .HasData(new
                {
                    Id = 1,
                    Name = "Bebida e comida"

                },
                new
                {
                    Id = 2,
                    Name = "Restauração"
                },
                new
                {
                    Id = 3,
                    Name = "Tecnologia"
                },
                new
                {
                    Id = 4,
                    Name = "Renda"
                }

            );

            bldr.Entity<SpentEntity>()
                .HasData(new
                {
                    Id = 1,
                    Name = "Continente"

                },
                new
                {
                    Id = 2,
                    Name = "Dellman"
                }
          );
        
        }


        public DbSet<Spent> Spents { get; set; }
        public DbSet<SpentEntity> SpentEntities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
