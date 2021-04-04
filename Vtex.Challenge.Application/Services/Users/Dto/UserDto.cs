using System.ComponentModel.DataAnnotations;

namespace Vtex.Challenge.Application.Services.Users.Dto
{
    public class UserDto
    {
        /// <example>admin</example>
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }

        /// <example>password</example>
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}