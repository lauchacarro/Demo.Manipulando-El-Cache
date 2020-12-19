using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CachePerEntity.Options
{
    public class MongoProductOptions : MongoOptions, IMongoProductOptions
    {
    }

    public interface IMongoProductOptions : IMongoOptions
    {

    }
}
