﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Waves.Services.Services.Models.User
{
    public class CreateUserModel
    {
        public Int32 RoleId { get; set; }
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        [Required]
        [MinLength(6)]
        public String Password { get; set; }
        [Required]
        [MinLength(6)]
        public String ConfirmPassword { get; set; }
    }
}
