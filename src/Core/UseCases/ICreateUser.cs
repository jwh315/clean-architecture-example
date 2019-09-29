using System.Threading.Tasks;

namespace User.Core.UseCases
{
    public interface ICreateUser
    {
        Task CreateAsync(Entities.User user);
    }
}