
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CachePerEntity.Caching
{
    public class CachedRepository : ICachedRepository
    {
        private readonly IMemoryKeyCache _memoryCache;

        public CachedRepository(IMemoryKeyCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public T GetOrSet<T>(CacheKey cacheKey, Func<T> getItemCallback) where T : class
        {
            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = getItemCallback();

                SetItemToCache(cacheKey, item);
            }

            return item;
        }

        public async Task<T> GetOrSetAsync<T>(CacheKey cacheKey, Func<Task<T>> getItemCallback) where T : class
        {
            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = await getItemCallback();

                SetItemToCache(cacheKey, item);
            }

            return item;
        }

        public void RemoveByEntity(string entity)
        {
            var keys = _memoryCache.GetKeys().Where(x => x is CacheKey key && key.Entity == entity);

            foreach (var key in keys)
            {
                _memoryCache.Remove(key);
            }
        }



        private void SetItemToCache<T>(CacheKey cacheKey, T item)
        {
            _memoryCache.Set(cacheKey, item);
        }
    }
}
