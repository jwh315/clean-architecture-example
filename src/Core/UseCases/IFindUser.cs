using System.Threading.Tasks;

namespace User.Core.UseCases
{
    public interface IFindUser
    {
        Task<Entities.User> ByIdAsync(int id);
    }
}