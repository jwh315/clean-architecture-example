using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Core.Exceptions;
using User.Core.Repositories;

namespace User.Infrastructure.InMemory
{
    public class UserMemoryRepository : IUserRepository
    {
        private static readonly List<Core.Entities.User> _users = new List<Core.Entities.User>();
        
        
        public Task Create(Core.Entities.User user)
        {
            var id = _users.Count + 1;

            user.Id = id;
            
            _users.Add(user);

            return Task.FromResult(true);
        }

        public Task<Core.Entities.User> FindUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                return Task.FromResult(user);
            }
            
            throw new UserNotFoundException($"User with id {id} could not be found");
        }
    }
}