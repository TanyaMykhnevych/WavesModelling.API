using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waves.Domain.Identity
{
    public class AppFeature
    {
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(128)]
        public String Name { get; set; }
        [MaxLength(2048)]
        public String Description { get; set; }
        public List<AppRoleFeature> AppRoles { get; set; }
    }
}
