
using Microsoft.Extensions.Caching.Memory;

using System.Collections.Generic;

namespace WebApi.CachePerRequest.Caching
{
    public interface IMemoryKeyCache : IMemoryCache
    {
        ICollection<object> GetKeys();
    }
}
