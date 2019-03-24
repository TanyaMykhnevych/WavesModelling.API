using System;
using System.ComponentModel.DataAnnotations;

namespace Waves.Services.Services.Models.User
{
    public class CreateUserModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int32 RoleId { get; set; }
        [EmailAddress]
        [Required]
        public String Email { get; set; }
        [Required]
        [MinLength(6)]
        public String Password { get; set; }
    }
}
