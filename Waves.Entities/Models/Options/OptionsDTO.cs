using System;
using Waves.Entities.Models.Base;

namespace Waves.Entities.Models.Options
{
    public class OptionsDTO : BaseEntityDTO
    {
        public Int32 D { get; set; }
        public Int32 N { get; set; }
        public Single Omega { get; set; }
        public Int32 W { get; set; }
        public Int32 R { get; set; }
        public Int32 KvisRange { get; set; }
        public Int32 ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
