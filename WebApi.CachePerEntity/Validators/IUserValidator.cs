
using AivenEcommerce.V1.Domain.Repositories;

using System;
using System.Threading.Tasks;

using WebApi.CachePerEntity.Entities;

namespace WebApi.CachePerEntity.Validators
{
    public interface IUserValidator
    {
        bool ValidateCreateUser(User user);
        Task<bool> ValidateUpdateUserAsync(User user);
    }
}
