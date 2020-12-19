using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

using WebApi.CachePerEntity.Entities;
using WebApi.CachePerEntity.Repositories;
using WebApi.CachePerEntity.Validators;

namespace WebApi.CachePerEntity.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _uservalidator;

        public UsersController(IUserRepository userRepository, IUserValidator uservalidator)
        {
            _userRepository = userRepository;
            _uservalidator = uservalidator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> Create(User userRequest)
        {
            var result = _uservalidator.ValidateCreateUser(userRequest);

            if (result)
            {
                User userEntry = await _userRepository.CreateAsync(userRequest);
                return Ok(userEntry);
            }

            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> Update(User userRequest)
        {
            bool result = await _uservalidator.ValidateUpdateUserAsync(userRequest);

            if (result)
            {
                User userEntry = await _userRepository.GetAsync(userRequest.Id);

                userEntry.Name = userRequest.Name;
                userEntry.Email = userRequest.Email;
                userEntry.Age = userRequest.Age;


                await _userRepository.UpdateAsync(userEntry);
                return Ok(userEntry);
            }

            return BadRequest();
        }
    }
}
