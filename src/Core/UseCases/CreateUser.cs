using System.Threading.Tasks;
using User.Core.Repositories;

namespace User.Core.UseCases
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(Entities.User user)
        {
            await _userRepository.Create(user);
        }
    }
}