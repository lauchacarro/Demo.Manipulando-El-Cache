using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CachePerEntity.Options
{
    public class MongoUserOptions : MongoOptions, IMongoUserOptions
    {
    }

    public interface IMongoUserOptions : IMongoOptions
    {

    }
}
