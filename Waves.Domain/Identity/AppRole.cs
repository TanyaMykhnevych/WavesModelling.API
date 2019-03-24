using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waves.Domain.Identity
{
    public class AppRole
    {
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(64)]
        public String Name { get; set; }
        public Boolean IsActive { get; set; }
        public List<AppRoleFeature> AppFeatures { get; set; }
    }
}
