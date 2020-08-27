using GandaSpents.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }
    }
}
