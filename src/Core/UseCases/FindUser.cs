using System.Threading.Tasks;
using User.Core.Repositories;

namespace User.Core.UseCases
{
    public class FindUser : IFindUser
    {
        private readonly IUserRepository _userRepository;

        public FindUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Entities.User> ByIdAsync(int id)
        {
            return await _userRepository.FindUserById(id);
        }
    }
}