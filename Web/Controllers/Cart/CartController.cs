using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Carts;

namespace Vtex.Challenge.Controllers.Cart
{
    /// <summary>
    /// Create, delete, update and read the contents of the cart
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private ICartService CartService;

        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _logger = logger;
            CartService = cartService;
        }

        /// <summary>
        /// Get an cart given an id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A bearer token to access the API</returns>
        /// <response code="200">Returns the cart with all information</response>
        /// <response code="204">Returns no content when id not found</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await CartService.GetCart(Id));
        }
    }
}