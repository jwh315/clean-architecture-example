using System.Threading.Tasks;

namespace User.Core.Repositories
{
    public interface IUserRepository
    {
        Task Create(Entities.User user);

        Task<Entities.User> FindUserById(int id);
    }
}