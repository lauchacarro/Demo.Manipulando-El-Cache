using System.Threading.Tasks;

using WebApi.RepositoryPatternWithoutCache.Entities;

namespace WebApi.RepositoryPatternWithoutCache.Validators
{
    public interface IProductValidator
    {
        bool ValidateCreateProduct(Product product);
        Task<bool> ValidateUpdateProductAsync(Product product);
    }
}
