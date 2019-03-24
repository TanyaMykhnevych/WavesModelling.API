using System;
using Waves.Entities.Models.Base;

namespace Waves.Entities.Models.User
{
    public class AppUserDTO : BaseEntityDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public Boolean IsActive { get; set; }
        public Int32 RoleId { get; set; }
        public AppRoleDTO Role { get; set; }
    }
}
