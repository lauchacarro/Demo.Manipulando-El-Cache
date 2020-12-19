
using AivenEcommerce.V1.Domain.Repositories;

using System;
using System.Threading.Tasks;

using WebApi.CachePerRequest.Entities;

namespace WebApi.CachePerRequest.Validators
{
    public interface IProductValidator
    {
        bool ValidateCreateProduct(Product product);
        Task<bool> ValidateUpdateProductAsync(Product product);
    }
}
