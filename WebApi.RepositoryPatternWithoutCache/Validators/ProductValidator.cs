using System.Threading.Tasks;

using WebApi.RepositoryPatternWithoutCache.Entities;
using WebApi.RepositoryPatternWithoutCache.Repositories;

namespace WebApi.RepositoryPatternWithoutCache.Validators
{
    public class ProductValidator : IProductValidator
    {
        private readonly IProductRepository _productRepository;

        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool ValidateCreateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                return false;

            if (product.Stock <= 0)
                return false;

            if (product.Price <= 0)
                return false;

            return true;
        }

        public async Task<bool> ValidateUpdateProductAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                return false;

            if (product.Stock <= 0)
                return false;

            if (product.Price <= 0)
                return false;



            Product productExistent = await _productRepository.GetAsync(product.Id);

            if (productExistent is null)
                return false;


            return true;
        }
    }
}
