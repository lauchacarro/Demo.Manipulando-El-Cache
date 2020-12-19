using System.Threading.Tasks;

using WebApi.CachePerEntity.Entities;
using WebApi.CachePerEntity.Repositories;

namespace WebApi.CachePerEntity.Validators
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateCreateUser(User userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.Name))
                return false;

            if (string.IsNullOrWhiteSpace(userRequest.Email))
                return false;

            if (userRequest.Age <= 0)
                return false;

            return true;
        }

        public async Task<bool> ValidateUpdateUserAsync(User userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.Name))
                return false;

            if (string.IsNullOrWhiteSpace(userRequest.Email))
                return false;

            if (userRequest.Age <= 0)
                return false;



            User userExistent = await _userRepository.GetAsync(userRequest.Id);

            if (userExistent is null)
                return false;


            return true;
        }
    }
}
