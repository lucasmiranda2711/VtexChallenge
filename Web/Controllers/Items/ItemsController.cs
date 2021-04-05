using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Items;

namespace Vtex.Challenge.Web.Controllers.Items
{
    /// <summary>
    /// Create, delete, update and read the items available.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {

        private IItemService ItemService;

        public ItemsController(IItemService itemService)
        {
            ItemService = itemService;
        }



        /// <summary>
        /// Get an item given an id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>An item with all his information</returns>
        /// <response code="200">Returns the item with all information</response>
        /// <response code="204">Returns no content when id not found</response>
        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> Get([Required] Guid Id)
        {
            var item = await ItemService.GetItem(Id);
            if (item == null)
                return NoContent();

            return Ok(item);
        }

        /// <summary>
        /// Get all items.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A list of item ids</returns>
        /// <response code="200">Returns a list of all items ids</response>
        /// <response code="204">Returns no content when id not found</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var cupoms = await ItemService.GetAllItems();
            if (cupoms == null)
                return NoContent();

            return Ok(cupoms);
        }

    }
}