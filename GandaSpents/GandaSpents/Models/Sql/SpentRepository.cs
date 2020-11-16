using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class SpentRepository : ISpentRepository
    {
        private readonly AppDbContext _dbContext;
        public SpentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Spent spent)
        {
            await _dbContext.Spents.AddAsync(spent);
        }

        public async Task DeleteAsync(string id)
        {
            var spent = await GetByIdAsync(id);
            if (spent != null)
            {
                _dbContext.Spents.Remove(spent);
            }
        }
        public void Update(Spent spent)
        {
            var entity = _dbContext.Spents.Attach(spent);
            entity.State = EntityState.Modified;
        }


        public IEnumerable<Spent> GetAll()
        {
            return _dbContext.Spents.Include(spent => spent.SpentEntity)
                                    .Include(spent => spent.Product);
        }

        public async Task<Spent> GetByIdAsync(string id)
        {
            return await _dbContext.Spents.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Spent> GetMonthSpents()
        {
            return _dbContext.Spents.Where(spent => spent.Date.Month == DateTime.Now.Month && spent.Date.Year == DateTime.Now.Year);
        }
    }
}
