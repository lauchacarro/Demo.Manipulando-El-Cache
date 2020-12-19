using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApi.CachePerEntity.Caching;
using WebApi.CachePerEntity.Entities;
using WebApi.CachePerEntity.Options;
using WebApi.CachePerEntity.Repositories.Base;

namespace WebApi.CachePerEntity.Repositories
{
    public class UserRepository : MongoRepository<User>, IUserRepository
    {
        private readonly ICachedRepository _cachedRepository;

        public UserRepository(IMongoUserOptions options, ICachedRepository cachedRepository) : base(options)
        {
            _cachedRepository = cachedRepository ?? throw new ArgumentNullException(nameof(cachedRepository));
        }

        public override Task<IEnumerable<User>> GetAllAsync()
        {
            return _cachedRepository.GetOrSetAsync(

                    new(nameof(User), nameof(GetAllAsync)),

                    () => base.GetAllAsync()
                );
        }

        public override Task<User> GetAsync(Guid id)
        {
            return _cachedRepository.GetOrSetAsync(

                    new(nameof(User), nameof(GetAsync), id.ToString()),

                    () => base.GetAsync(id)
                );
        }

        public override async Task<User> CreateAsync(User entity)
        {
            var product = await base.CreateAsync(entity);

            _cachedRepository.RemoveByEntity(nameof(User));

            return product;
        }

        public override async Task UpdateAsync(User entity)
        {
            await base.UpdateAsync(entity);

            _cachedRepository.RemoveByEntity(nameof(User));
        }

        public override async Task RemoveAsync(User entity)
        {
            await base.RemoveAsync(entity);

            _cachedRepository.RemoveByEntity(nameof(User));
        }
        public override async Task RemoveAllAsync()
        {
            await base.RemoveAllAsync();

            _cachedRepository.RemoveByEntity(nameof(User));
        }
    }
}
