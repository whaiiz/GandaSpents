using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models.Repositories
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task DeleteAsync(string id);
        void Update(Product product);
        IEnumerable<Product> GetAll();
        Task<Product> GetByIdAsync(string id);
        Task SaveChangesAsync();
    }
}
