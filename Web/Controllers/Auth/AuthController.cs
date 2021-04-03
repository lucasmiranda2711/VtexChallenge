using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vtex.Challenge.Database_.Repository.Auth;
using Vtex.Challenge.Domain.Service.Auth;
using Vtex.Challenge.Web.Dto;

namespace Vtex.Challenge.Web.Controllers.Auth
{
    public class AuthController : ControllerBase
    {
        private IUserRepository UserRepository;
        private ITokenService TokenService;

        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            UserRepository = userRepository;
            TokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserDto userDto)
        {
            // Recupera o usuário
            var user = await UserRepository.Get(userDto.Username, userDto.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = await TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}