using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class SpentRepository : Repository<Spent>, ISpentRepository
    {
        public SpentRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }

        public override IEnumerable<Model> GetAll()
        {
            return _dbContext.Spents.Include(spent => spent.SpentEntity)
                                    .Include(spent => spent.Product);
        }

        public IEnumerable<Spent> GetMonthSpents()
        {
            return _dbContext.Spents.Where(spent => spent.Date.Month == DateTime.Now.Month && spent.Date.Year == DateTime.Now.Year);
        }
    }
}
