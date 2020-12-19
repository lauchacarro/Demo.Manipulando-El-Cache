
using AivenEcommerce.V1.Domain.Repositories;

using System;
using System.Threading.Tasks;

using WebApi.CachePerEntity.Entities;

namespace WebApi.CachePerEntity.Validators
{
    public interface IProductValidator
    {
        bool ValidateCreateProduct(Product product);
        Task<bool> ValidateUpdateProductAsync(Product product);
    }
}
