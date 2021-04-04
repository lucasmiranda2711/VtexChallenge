using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Auth;

namespace Vtex.Challenge.Database.Repository.Auth
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "admin", Password = "admin", Role = "manager" });

            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}