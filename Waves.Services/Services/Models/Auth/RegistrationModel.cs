using System;
using System.ComponentModel.DataAnnotations;

namespace Waves.Services.Services.Models.Auth
{
    public class RegistrationModel
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String ConfirmPassword { get; set; }
    }
}
