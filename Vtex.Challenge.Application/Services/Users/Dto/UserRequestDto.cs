using System.ComponentModel.DataAnnotations;

namespace Vtex.Challenge.Application.Services.Users.Dto
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}