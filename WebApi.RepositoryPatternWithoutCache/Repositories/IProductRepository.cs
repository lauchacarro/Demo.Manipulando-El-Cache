
using System;
using System.Threading.Tasks;

using WebApi.RepositoryPatternWithoutCache.Entities;
using WebApi.RepositoryPatternWithoutCache.Repositories.Base;

namespace WebApi.RepositoryPatternWithoutCache.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<Product> GetAsync(Guid id);
    }
}