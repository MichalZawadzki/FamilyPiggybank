using System.ComponentModel.DataAnnotations;

namespace FamilyPiggybank.API.Models.Identity
{
    public class LoginUserRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
