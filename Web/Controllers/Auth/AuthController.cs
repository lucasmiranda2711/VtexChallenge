using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vtex.Challenge.Database_.Repository.Auth;
using Vtex.Challenge.Domain.Service.Auth;
using Vtex.Challenge.Web.Dto;

namespace Vtex.Challenge.Web.Controllers.Auth
{
    /// <summary>
    /// Controller for validation handling.
    /// </summary>
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository UserRepository;
        private ITokenService TokenService;

        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            UserRepository = userRepository;
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
        [Route("login")]
        [Produces("application/json")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
        {   
            var user = await UserRepository.Get(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = await TokenService.GenerateToken(user);

            user.Password = "";

            return Ok(new
            {
                user = user,
                token = token
            });
        }
    }
}