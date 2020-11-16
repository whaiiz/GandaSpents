using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public interface ISpentRepository
    {
        Task CreateAsync(Spent spent);
        Task DeleteAsync(string id);
        void Update(Spent spent);
        IEnumerable<Spent> GetAll();
        Task<Spent> GetByIdAsync(string id);
        Task SaveChangesAsync();
        IEnumerable<Spent> GetMonthSpents();
    }
}
