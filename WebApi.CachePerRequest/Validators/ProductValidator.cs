using System.Threading.Tasks;

using WebApi.CachePerRequest.Entities;
using WebApi.CachePerRequest.Repositories;

namespace WebApi.CachePerRequest.Validators
{
    public class ProductValidator : IProductValidator
    {
        private readonly IProductRepository _productRepository;

        public ProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool ValidateCreateProduct(Product productRequest)
        {
            if (string.IsNullOrWhiteSpace(productRequest.Name))
                return false;

            if (productRequest.Stock <= 0)
                return false;

            if (productRequest.Price <= 0)
                return false;

            return true;
        }

        public async Task<bool> ValidateUpdateProductAsync(Product productRequest)
        {
            if (string.IsNullOrWhiteSpace(productRequest.Name))
                return false;

            if (productRequest.Stock <= 0)
                return false;

            if (productRequest.Price <= 0)
                return false;



            Product productExistent = await _productRepository.GetAsync(productRequest.Id);

            if (productExistent is null)
                return false;


            return true;
        }
    }
}
