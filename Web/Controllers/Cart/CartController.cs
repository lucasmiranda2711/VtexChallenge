using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
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
        public async Task<IActionResult> Get([Required] Guid Id)
        {
            var cart = await CartService.GetCart(Id);
            if (cart == null)
                return NoContent();

            return Ok(cart);
        }

        /// <summary>
        /// Creates a new cart and returns his id.
        /// </summary>
        /// <returns>A bearer token to access the API</returns>
        /// <response code="200">Returns when the cart is created correctly</response>
        /// <response code="400">Returns when an error occurs creating the cart</response>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post()
        {
            var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var cartId = await CartService.CreateCart(UserId);

            return Ok(cartId);
        }

        /// <summary>
        /// Removes all cart items.
        /// </summary>
        /// <returns>A bearer token to access the API</returns>
        /// <response code="200">Returns when the cart is cleaned correctly</response>
        /// <response code="400">Returns when an error occurs cleaning the cart</response>
        [HttpPut("/clean")]
        [Authorize]
        public async Task<IActionResult> Clean([Required] Guid Id)
        {
            if (await CartService.CleanCart(Id)) return Ok();

            return BadRequest("The cart was not found");
        }

        /// <summary>
        /// Add a discount cupom.
        /// </summary>
        /// <returns>A bearer token to access the API</returns>
        /// <response code="200">Returns when the cart is cleaned correctly</response>
        /// <response code="400">Returns when an error occurs cleaning the cart</response>
        [HttpPut("/addCupom")]
        [Authorize]
        public async Task<IActionResult> AddCupom([Required] Guid Id)
        {
            return null;
        }
    }
}