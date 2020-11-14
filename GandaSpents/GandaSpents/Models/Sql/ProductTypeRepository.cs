using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository 
    {

        public ProductTypeRepository(AppDbContext appDbContext): base(appDbContext)
        {
            
        }

        public override IEnumerable<Model> GetAll()
        {
            return _dbContext.ProductTypes;
        }

        public bool AlreadyExists(string name)
        {
            if (_dbContext.ProductTypes.FirstOrDefault(p => p.Name == name) == null) return false;
            return true;
        }
    }
}
