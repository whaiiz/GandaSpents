using GandaSpents.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class SpentRepository : Repository, ISpentRepository
    {
        public SpentRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }
    }
}
