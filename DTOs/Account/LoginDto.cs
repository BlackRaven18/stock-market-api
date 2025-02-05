using System.ComponentModel.DataAnnotations;

namespace dotnet_web_api.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
