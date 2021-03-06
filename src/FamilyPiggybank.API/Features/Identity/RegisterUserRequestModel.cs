﻿using System.ComponentModel.DataAnnotations;

namespace FamilyPiggybank.API.Models.Identity
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
