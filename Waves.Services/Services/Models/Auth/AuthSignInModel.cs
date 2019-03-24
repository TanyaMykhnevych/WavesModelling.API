using System;
using System.ComponentModel.DataAnnotations;

namespace Waves.Services.Services.Models.Auth
{
    public class AuthSignInModel
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
