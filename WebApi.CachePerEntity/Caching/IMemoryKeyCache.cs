
using Microsoft.Extensions.Caching.Memory;

using System.Collections.Generic;

namespace WebApi.CachePerEntity.Caching
{
    public interface IMemoryKeyCache : IMemoryCache
    {
        ICollection<object> GetKeys();
    }
}
