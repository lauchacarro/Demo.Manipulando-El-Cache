using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using MongoDB.Driver;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApi.SwitchCache.Entities;
using WebApi.SwitchCache.Options;

namespace WebApi.SwitchCache.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        protected readonly IMongoCollection<Product> _collection;

        public ProductsController(IMemoryCache memoryCache, IMongoOptions options)
        {
            _memoryCache = memoryCache;

            var client = new MongoClient(options.ConnectionString);
            var database = client.GetDatabase(options.DatabaseName);

            _collection = database.GetCollection<Product>(options.CollectionName);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> GetAll([FromQuery] bool useCache)
        {
            string cacheKey = nameof(Product);


            if (!useCache || _memoryCache.Get(cacheKey) is not List<Product> items)
            {
                items = await _collection.AsQueryable().ToListAsync();

                _memoryCache.Set(cacheKey, items);
            }



            return Ok(items);
        }
    }
}
