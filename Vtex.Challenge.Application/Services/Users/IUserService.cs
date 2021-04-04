using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Auth;

namespace Vtex.Challenge.Application.Services.Users
{
    public interface IUserService
    {
        Task<User> GetUser(string username, string password);
    }
}
