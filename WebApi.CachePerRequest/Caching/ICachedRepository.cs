
using System;
using System.Threading.Tasks;

namespace WebApi.CachePerRequest.Caching
{
    public interface ICachedRepository
    {
        T GetOrSet<T>(ScopedCacheKey cacheKey, Func<T> getItemCallback) where T : class;
        Task<T> GetOrSetAsync<T>(ScopedCacheKey cacheKey, Func<Task<T>> getItemCallback) where T : class;
    }
}
