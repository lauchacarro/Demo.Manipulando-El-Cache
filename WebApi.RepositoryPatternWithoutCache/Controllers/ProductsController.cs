using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using WebApi.RepositoryPatternWithoutCache.Entities;
using WebApi.RepositoryPatternWithoutCache.Repositories;
using WebApi.RepositoryPatternWithoutCache.Validators;

namespace WebApi.RepositoryPatternWithoutCache.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductValidator _productvalidator;

        public ProductsController(IProductRepository productRepository, IProductValidator productvalidator)
        {
            _productRepository = productRepository;
            _productvalidator = productvalidator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> Create(Product productRequest)
        {
            var result = _productvalidator.ValidateCreateProduct(productRequest);

            if (result)
            {
                Product productEntry = await _productRepository.CreateAsync(productRequest);
                return Ok(productEntry);
            }

            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> Update(Product productRequest)
        {
            var result = _productvalidator.ValidateCreateProduct(productRequest);

            if (result)
            {
                Product productEntry = await _productRepository.GetAsync(productRequest.Id);

                productEntry.Name = productRequest.Name;
                productEntry.Price = productRequest.Price;
                productEntry.Stock = productRequest.Stock;
                productEntry.IsActive = productRequest.IsActive;


                await _productRepository.UpdateAsync(productEntry);
                return Ok(productEntry);
            }

            return BadRequest();
        }
    }
}
