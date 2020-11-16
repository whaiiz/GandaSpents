using GandaSpents.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public interface IProductTypeRepository
    {
        Task CreateAsync(ProductType productType);
        Task DeleteAsync(string id);
        void Update(ProductType productType);
        IEnumerable<ProductType> GetAll();
        Task<ProductType> GetByIdAsync(string id);
        Task SaveChangesAsync();
        Task<bool> AlreadyExistsAsync(string name);

    }
}
