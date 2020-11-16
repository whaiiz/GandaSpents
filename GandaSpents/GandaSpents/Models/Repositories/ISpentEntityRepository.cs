using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public interface ISpentEntityRepository
    {
        Task CreateAsync(SpentEntity spentEntity);
        Task DeleteAsync(string id);
        void Update(SpentEntity spentEntity);
        IEnumerable<SpentEntity> GetAll();
        Task<SpentEntity> GetByIdAsync(string id);
        Task SaveChangesAsync();
        Task<bool> AlreadyExistsAsync(string name);
    }
}
