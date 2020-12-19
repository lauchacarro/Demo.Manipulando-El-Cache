using System.Threading.Tasks;

using WebApi.RepositoryPatternAndCache.Entities;

namespace WebApi.RepositoryPatternAndCache.Validators
{
    public interface IProductValidator
    {
        bool ValidateCreateProduct(Product product);
        Task<bool> ValidateUpdateProductAsync(Product product);
    }
}
