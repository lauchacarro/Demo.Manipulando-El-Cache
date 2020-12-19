
using System;
using System.Threading.Tasks;

using WebApi.RepositoryPatternAndCache.Entities;
using WebApi.RepositoryPatternAndCache.Repositories.Base;

namespace WebApi.RepositoryPatternAndCache.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Product> GetAsync(Guid id);
    }
}