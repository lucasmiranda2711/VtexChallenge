using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Cupoms;

namespace Vtex.Challenge.Web.Controllers.Cupoms
{
    /// <summary>
    /// Create, delete, update and read the cupoms available.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CupomController : ControllerBase
    {
        private ICupomService CupomService;

        public CupomController(ICupomService cupomService)
        {
            CupomService = cupomService;
        }


        /// <summary>
        /// Get a cupom given an id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A cupom with all his information</returns>
        /// <response code="200">Returns the cupom with all information</response>
        /// <response code="204">Returns no content when id not found</response>
        [HttpGet("{Id}")]
        [Authorize]
        public async Task<IActionResult> Get([Required] Guid Id)
        {
            var cupom = await CupomService.GetCupom(Id);
            if (cupom == null)
                return NoContent();

            return Ok(cupom);
        }

        /// <summary>
        /// Get all cupoms.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>A list of cupom ids</returns>
        /// <response code="200">Returns a list of cupom ids</response>
        /// <response code="204">Returns no content when id not found</response>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var cupoms = await CupomService.GetAllCupoms();
            if (cupoms == null)
                return NoContent();

            return Ok(cupoms);
        }
    }
}