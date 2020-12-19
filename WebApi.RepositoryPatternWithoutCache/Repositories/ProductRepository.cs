using Microsoft.Extensions.Caching.Memory;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApi.RepositoryPatternWithoutCache.Entities;
using WebApi.RepositoryPatternWithoutCache.Options;
using WebApi.RepositoryPatternWithoutCache.Repositories.Base;

namespace WebApi.RepositoryPatternWithoutCache.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IMongoOptions options) : base(options)
        {
        }
    }
}
