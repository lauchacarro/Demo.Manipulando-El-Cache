
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

using System;
using System.Threading.Tasks;

namespace WebApi.RepositoryPatternAndCache.Caching
{
    public class CachedRepository : ICachedRepository
    {
        private readonly IMemoryCache _memoryCache;

        public CachedRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public T GetOrSet<T>(ScopedCacheKey cacheKey, Func<T> getItemCallback) where T : class
        {
            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = getItemCallback();

                SetItemToCache(cacheKey, item);
            }

            return item;
        }

        public async Task<T> GetOrSetAsync<T>(ScopedCacheKey cacheKey, Func<Task<T>> getItemCallback) where T : class
        {
            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = await getItemCallback();

                SetItemToCache(cacheKey, item);
            }

            return item;
        }

        private void SetItemToCache<T>(ScopedCacheKey cacheKey, T item)
        {
            _memoryCache.Set(cacheKey, item, TimeSpan.FromMinutes(5));
        }
    }
}
