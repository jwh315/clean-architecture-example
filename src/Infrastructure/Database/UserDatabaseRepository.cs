using System.Threading.Tasks;
using User.Core.Exceptions;
using User.Core.Repositories;

namespace User.Infrastructure.Database
{
    public class UserDatabaseRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserDatabaseRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        
        public async Task Create(Core.Entities.User user)
        {
            var newUser = _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task<Core.Entities.User> FindUserById(int id)
        {
            var user = await _userContext.FindAsync<Core.Entities.User>(id);

            if (user != null)
            {
                return user;
            }
            
            throw new UserNotFoundException($"User with id {id} could not be found");
        }
    }
}