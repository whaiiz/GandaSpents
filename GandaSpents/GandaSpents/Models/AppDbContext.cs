using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder bldr)
        {
            /* DateTime DT = new DateTime(2015, 06, 27);

            bldr.Entity<ProductType>()
                .HasData(new
                {
                    Id = 1,
                    Name = "Bebida e comida",
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"

                },
                new
                {
                    Id = 2,
                    Name = "Restauração",
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"
                },
                new
                {
                    Id = 3,
                    Name = "Tecnologia",
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"
                },
                new
                {
                    Id = 4,
                    Name = "Renda",
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"
                }

            );

            bldr.Entity<SpentEntity>()
                .HasData(new
                {
                    Id = 1,
                    Name = "Continente",
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"

                },
                new
                {
                    Id = 2,
                    Name = "Dellman",
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"
                }
            );

            bldr.Entity<Product>()
                .HasData(new
                {
                    Id = 1,
                    name = "Frango",
                    ProductTypeId = 1,
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"

                }
            );

            bldr.Entity<Spent>()
                .HasData(new
                {
                    Id = 1,
                    Amount = 2,
                    Price =  3.3d,
                    ProductId = 1,
                    SpentEntityId = 1,
                    Date = DT,
                    UserId = "afc72ea6-58c4-48c2-9658-c0bc021e8f37"

                }
            );

            */ 
            base.OnModelCreating(bldr);

        }


        public DbSet<Spent> Spents { get; set; }
        public DbSet<SpentEntity> SpentEntities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
 
      
    }
}
