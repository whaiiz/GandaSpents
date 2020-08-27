using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class ProductTypeRepository : Repository, IProductTypeRepository
    {

        public ProductTypeRepository(AppDbContext appDbContext): base(appDbContext)
        {
            
        }
   
    }
}
