using System.Threading.Tasks;
using Vtex.Challenge.Database.Repository.Auth;
using Vtex.Challenge.Domain.Model.Auth;

namespace Vtex.Challenge.Application.Services.Users
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<User> GetUser(string username, string password)
        {
            return await UserRepository.Get(username, password);
        }
    }
}