using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model;

namespace Vtex.Challenge.Database_.Repository.Auth
{
    public interface IUserRepository
    {
        Task<User> Get(string username, string password);
    }
}