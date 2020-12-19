
using System;
using System.Threading.Tasks;

namespace WebApi.CachePerEntity.Caching
{
    public interface ICachedRepository
    {
        T GetOrSet<T>(CacheKey cacheKey, Func<T> getItemCallback) where T : class;
        Task<T> GetOrSetAsync<T>(CacheKey cacheKey, Func<Task<T>> getItemCallback) where T : class;

        void RemoveByEntity(string entity);
    }
}
