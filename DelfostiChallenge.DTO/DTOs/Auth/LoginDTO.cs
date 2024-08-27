using System.ComponentModel.DataAnnotations;

namespace DelfostiChallenge.DTO.DTOs.Auth
{
    public class LoginDTO
    {
        private string _username = string.Empty;

        [Required]
        [EmailAddress]
        public string Username
        {
            get => _username;
            set => _username = value?.Trim().ToUpper() ?? string.Empty;
        }

        [Required]
        public string Password { get; set; }
    }
}
