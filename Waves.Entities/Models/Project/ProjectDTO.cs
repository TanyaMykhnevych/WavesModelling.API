using System;
using Waves.Entities.Models.Base;
using Waves.Entities.Models.Options;
using Waves.Entities.Models.User;

namespace Waves.Entities.Models
{
    public class ProjectDTO : BaseEntityDTO
    {
        public String Name { get; set; }
        public Boolean IsShared { get; set; }
        public SeaDTO Sea { get; set; }
        public OptionsDTO Options { get; set; }
        public Int32? UserId { get; set; }
        public AppUserDTO User { get; set; }
    }
}
