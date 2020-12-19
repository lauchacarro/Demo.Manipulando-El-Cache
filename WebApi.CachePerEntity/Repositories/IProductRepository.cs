using AivenEcommerce.V1.Domain.Repositories;

using System;
using System.Threading.Tasks;

using WebApi.CachePerEntity.Entities;

namespace WebApi.CachePerEntity.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Product> GetAsync(Guid id);
    }
}