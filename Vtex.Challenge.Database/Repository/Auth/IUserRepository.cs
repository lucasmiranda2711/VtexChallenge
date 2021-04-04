using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Auth;

namespace Vtex.Challenge.Database.Repository.Auth
{
    public interface IUserRepository
    {
        Task<User> Get(string username, string password);

        Task<User> GetById(int userId);
    }
}