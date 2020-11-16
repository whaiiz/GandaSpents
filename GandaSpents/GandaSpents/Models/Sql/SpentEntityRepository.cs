using GandaSpents.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Sql
{
    public class SpentEntityRepository : ISpentEntityRepository
    {
        private readonly AppDbContext _dbContext;

        public SpentEntityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(SpentEntity spentEntity)
        {
            await _dbContext.SpentEntities.AddAsync(spentEntity);
        }

        public async Task DeleteAsync(string id)
        {
            var spentEntity = await GetByIdAsync(id);
            if (spentEntity != null)
            {
                _dbContext.SpentEntities.Remove(spentEntity);
            }
        }
        public void Update(SpentEntity spentEntity)
        {
            var entity = _dbContext.SpentEntities.Attach(spentEntity);
            entity.State = EntityState.Modified;
        }

        public IEnumerable<SpentEntity> GetAll()
        {
            return _dbContext.SpentEntities;
        }

        public async Task<SpentEntity> GetByIdAsync(string id)
        {
            return await _dbContext.SpentEntities.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AlreadyExistsAsync(string name)
        {
            if (await _dbContext.SpentEntities.FirstOrDefaultAsync(p => p.Name == name) == null) return false;
            return true;
        }
    }
}
