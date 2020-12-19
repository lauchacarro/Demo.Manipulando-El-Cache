
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

using System;
using System.Threading.Tasks;

namespace WebApi.CachePerRequest.Caching
{
    public class CachedRepository : ICachedRepository
    {
        private readonly IMemoryKeyCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CachedRepository(IMemoryKeyCache memoryCache, IHttpContextAccessor correlationContext)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _httpContextAccessor = correlationContext ?? throw new ArgumentNullException(nameof(correlationContext));
        }

        public T GetOrSet<T>(CacheKey cacheKey, Func<T> getItemCallback) where T : class
        {
            cacheKey.TraceIdentifierId = _httpContextAccessor.HttpContext.TraceIdentifier;

            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = getItemCallback();

                SetItemToCache(cacheKey, item);
            }

            return item;
        }

        public async Task<T> GetOrSetAsync<T>(CacheKey cacheKey, Func<Task<T>> getItemCallback) where T : class
        {
            cacheKey.TraceIdentifierId = _httpContextAccessor.HttpContext.TraceIdentifier;

            if (_memoryCache.Get(cacheKey) is not T item)
            {
                item = await getItemCallback();

                SetItemToCache(cacheKey, item);
            }

            return item;
        }

        private void SetItemToCache<T>(CacheKey cacheKey, T item)
        {
            _memoryCache.Set(cacheKey, item);
        }
    }
}
