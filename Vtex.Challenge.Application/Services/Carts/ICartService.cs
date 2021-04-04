using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Carts;

namespace Vtex.Challenge.Application.Services.Carts
{
    public interface ICartService
    {
        Task<Cart> GetCart(int Id);
    }
}
