using System;
using System.ComponentModel.DataAnnotations;

namespace Waves.Services.Services.Models.User
{
    public class UpdateUserModel
    {
        public Int32 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        public Int32 RoleId { get; set; }
        [MinLength(6)]
        public String Password { get; set; }
        [MinLength(6)]
        public String NewPassword { get; set; }
        [MinLength(6)]
        public String ConfirmPassword { get; set; }
        public Boolean IsActive { get; set; }
    }
}
