using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using Waves.Domain.Identity;
using Waves.Domain.Models.Base;

namespace Waves.Domain.Models.User
{
    public class AppUser : IdentityUser<Int32>, IBaseEntity
    {
        [MaxLength(32)]
        public String FirstName { get; set; }
        [MaxLength(32)]
        public String LastName { get; set; }
        public Boolean IsActive { get; set; }
        public Int32 RoleId { get; set; }
        public AppRole Role { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
