using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Auth;

namespace Vtex.Challenge.Database.Repository.Auth
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public UserRepository()
        {
            users.Add(new User { Id = 1, UserName = "admin", Password = "admin", Role = "manager" });
        }

        public async Task<User> Get(string username, string password)
        {
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }

        public async Task<User> GetById(int userId)
        {
            return users.Where(x => userId == x.Id).FirstOrDefault();
        }
    }
}