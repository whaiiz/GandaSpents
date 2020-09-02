using GandaSpents.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class SpentEntityRepository : Repository<SpentEntity>, ISpentEntityRepository
    {
        public SpentEntityRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }
    }
}
