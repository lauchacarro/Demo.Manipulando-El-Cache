
using System;
using System.Threading.Tasks;

using WebApi.CachePerRequest.Caching;
using WebApi.CachePerRequest.Entities;
using WebApi.CachePerRequest.Options;
using WebApi.CachePerRequest.Repositories.Base;

namespace WebApi.CachePerRequest.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        private readonly ICachedRepository _cachedRepository;

        public ProductRepository(IMongoOptions options, ICachedRepository cachedRepository) : base(options)
        {
            _cachedRepository = cachedRepository ?? throw new ArgumentNullException(nameof(cachedRepository));
        }


        public override Task<Product> GetAsync(Guid id)
        {
            return _cachedRepository.GetOrSetAsync(

                    new(nameof(Product), nameof(GetAsync), id.ToString()),

                    () => base.GetAsync(id)
                );
        }
    }
}
