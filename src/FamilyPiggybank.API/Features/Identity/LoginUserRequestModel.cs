using System.ComponentModel.DataAnnotations;

namespace FamilyPiggybank.API.Models.Identity
{
    public class LoginUserRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
