using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Spent> Spents { get; set; }
        public DbSet<SpentEntity> SpentEntities { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
