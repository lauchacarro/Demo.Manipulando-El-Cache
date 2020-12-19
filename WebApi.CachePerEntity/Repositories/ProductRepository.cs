
using System;
using System.Threading.Tasks;

using WebApi.CachePerEntity.Caching;
using WebApi.CachePerEntity.Entities;
using WebApi.CachePerEntity.Options;
using WebApi.CachePerEntity.Repositories.Base;

namespace WebApi.CachePerEntity.Repositories
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

        public override async Task<Product> CreateAsync(Product entity)
        {
            var product = await base.CreateAsync(entity);

            _cachedRepository.RemoveByEntity(nameof(Product));

            return product;
        }

        public override async Task UpdateAsync(Product entity)
        {
            await base.UpdateAsync(entity);

            _cachedRepository.RemoveByEntity(nameof(Product));
        }

        public override async Task RemoveAsync(Product entity)
        {
            await base.RemoveAsync(entity);

            _cachedRepository.RemoveByEntity(nameof(Product));
        }
        public override async Task RemoveAllAsync()
        {
            await base.RemoveAllAsync();

            _cachedRepository.RemoveByEntity(nameof(Product));
        }
    }
}
