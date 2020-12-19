
using Microsoft.AspNetCore.Http;

using System;
using System.Threading.Tasks;

using WebApi.CachePerRequest.Caching;

namespace WebApi.CachePerRequest.Middlewares
{
    public class TraceCacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryKeyCache _cache;

        public TraceCacheMiddleware(RequestDelegate next, IMemoryKeyCache cache)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            var keys = _cache.GetKeys();

            foreach (var cacheKey in keys)
            {
                if (cacheKey is CacheKey key && key.TraceIdentifierId == context.TraceIdentifier)
                {
                    _cache.Remove(cacheKey);
                }
            }
        }
    }
}
