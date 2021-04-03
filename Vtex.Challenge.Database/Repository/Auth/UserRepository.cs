using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model;

namespace Vtex.Challenge.Database_.Repository.Auth
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, UserName = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}