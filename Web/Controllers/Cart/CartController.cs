using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Carts;
using Vtex.Challenge.Application.Services.Carts.Dto;
using Vtex.Challenge.Application.Services.Items;

namespace Vtex.Challenge.Controllers.Cart
{
    /// <summary>
    /// Create, delete, update and read the contents of the cart
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private ICartService CartService;
        private IMapper Mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            CartService = cartService;
            Mapper = mapper;
        }

        /// <summary>
        /// Get a cart given an id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A cart with all his information</returns>
        /// <response code="200">Returns the cart with all information</response>
        /// <response code="204">Returns no content when id not found</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([Required] Guid Id)
        {
            var cart = Mapper.Map<CartDto>(await  CartService.GetCart(Id));
            if (cart == null)
                return NoContent();

            return Ok(cart);
        }

        /// <summary>
        /// Creates a new cart and returns his id.
        /// </summary>
        /// <returns>An id of the created cart</returns>
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
        /// <response code="200">Returns when the cart is cleaned correctly</response>
        /// <response code="400">Returns when an error occurs cleaning the cart</response>
        [HttpPut("/Clean")]
        [Authorize]
        public async Task<IActionResult> Clean([Required] Guid Id)
        {
            if (await CartService.CleanCart(Id)) return Ok();

            return BadRequest("The cart was not found");
        }

        /// <summary>
        /// Add a discount cupom.
        /// </summary>
        /// <response code="200">Returns when the cart is cleaned correctly</response>
        /// <response code="400">Returns when an error occurs cleaning the cart</response>
        [HttpPut("/AddCupom")]
        [Authorize]
        public async Task<IActionResult> AddCupom([Required] Guid CartId, [Required]  Guid CupomId)
        {
            if (await CartService.AddCupom(CartId, CupomId)) return Ok();

            return BadRequest("An error occured while trying to add your cupom.");
        }

        /// <summary>
        /// Add an item.
        /// </summary>
        /// <response code="200">Returns when the item is added correctly</response>
        /// <response code="400">Returns when an error occurs adding the item</response>
        [HttpPut("/AddItem")]
        [Authorize]
        public async Task<IActionResult> AddItem(ItemRequestDto itemRequestDto)
        {
            if (await CartService.AddItem(itemRequestDto)) return Ok();

            return BadRequest("An error occured while trying to add your item.");
        }

        /// <summary>
        /// Remove an item from cart.
        /// </summary>
        /// <response code="200">Returns when the item is removed correctly</response>
        /// <response code="400">Returns when an error occurs removing the item</response>
        [HttpPut("/RemoveItem")]
        [Authorize]
        public async Task<IActionResult> RemoveItem(Guid cartId, Guid itemId)
        {
            if (await CartService.RemoveItem(cartId, itemId)) return Ok();

            return BadRequest("An error occured while trying to remove your item.");
        }

        /// <summary>
        /// Update an item from cart.
        /// </summary>
        /// <response code="200">Returns when the cart item is updated correctly</response>
        /// <response code="400">Returns when an error occurs updating the cart</response>
        [HttpPut("/UpdateItem")]
        [Authorize]
        public async Task<IActionResult> UpdateItem(ItemRequestDto itemRequestDto)
        {
            if (await CartService.UpdateItem(itemRequestDto)) return Ok();

            return BadRequest("An error occured while trying to update your item.");
        }
    }
}