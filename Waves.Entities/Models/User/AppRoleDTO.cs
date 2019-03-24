using System;
using System.ComponentModel.DataAnnotations;

namespace Waves.Entities.Models.User
{
    public class AppRoleDTO
    {
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
        public Boolean IsActive { get; set; }
    }
}
