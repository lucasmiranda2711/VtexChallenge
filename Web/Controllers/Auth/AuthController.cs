using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vtex.Challenge.Application.Services.Users;
using Vtex.Challenge.Application.Services.Users.Dto;
using Vtex.Challenge.Domain.Service.Auth;

namespace Vtex.Challenge.Web.Controllers.Auth
{
    /// <summary>
    /// Controller for validation handling.
    /// </summary>
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService TokenService;
        private IUserService UserService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            UserService = userService;
            TokenService = tokenService;
        }

        /// <summary>
        /// Login to gerenerate a token to access the other components.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>A bearer token to access the API</returns>
        /// <response code="200">Returns the bearer</response>
        /// <response code="400">Returns if login information has invalid values</response>
        /// <response code="401">Returns if the user/password is incorrect.</response>
        [HttpPost]
        [Route("Login")]
        [Produces("application/json")]
        public async Task<IActionResult> Authenticate([FromBody] UserRequestDto userDto)
        {
            var user = await UserService.GetUser(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = await TokenService.GenerateToken(user);

            return Ok(new
            {
                token = token
            });
        }
    }
}