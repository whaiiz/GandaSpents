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

        public bool AlreadyExists(string name)
        {
            if (_dbContext.SpentEntities.FirstOrDefault(p => p.Name == name) == null) return false;
            return true;
        }
    }
}
