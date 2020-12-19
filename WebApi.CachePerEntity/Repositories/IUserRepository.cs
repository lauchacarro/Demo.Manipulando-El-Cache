using AivenEcommerce.V1.Domain.Repositories;

using System;

using WebApi.CachePerEntity.Entities;

namespace WebApi.CachePerEntity.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
