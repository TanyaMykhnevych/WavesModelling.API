using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Waves.Domain.Models.Base;
using Waves.Domain.Models.User;

namespace Waves.Domain.Models
{
    public class Project : BaseEntity
    {
        [MaxLength(50)]
        public String Name { get; set; }
        public Boolean IsShared { get; set; }
        public Sea Sea { get; set; }
        public Options Options { get; set; }

        [ForeignKey("User")]
        public Int32? UserId { get; set; }
        public AppUser User { get; set; }
    }
}
