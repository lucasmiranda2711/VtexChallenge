using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model;

namespace Vtex.Challenge.Domain.Service.Auth
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}