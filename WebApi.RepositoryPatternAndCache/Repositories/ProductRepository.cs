
using System;
using System.Threading.Tasks;

using WebApi.RepositoryPatternAndCache.Caching;
using WebApi.RepositoryPatternAndCache.Entities;
using WebApi.RepositoryPatternAndCache.Options;
using WebApi.RepositoryPatternAndCache.Repositories.Base;

namespace WebApi.RepositoryPatternAndCache.Repositories
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
