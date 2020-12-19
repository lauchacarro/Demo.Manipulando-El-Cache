
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApi.RepositoryPatternWithoutCache.Entities;

namespace WebApi.RepositoryPatternWithoutCache.Repositories.Base
{
    public interface IRepository<T, K> where T : IEntity<K>
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(K id);
        Task RemoveAsync(K id);
        Task RemoveAsync(T entityIn);
        Task RemoveAllAsync();
        Task UpdateAsync(T entityIn);
    }
}