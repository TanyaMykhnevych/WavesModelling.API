using System;
using System.Collections.Generic;
using Waves.Entities.Models.Base;
using Waves.Entities.Models.Isle;
using Waves.Entities.Models.Oscillator;

namespace Waves.Entities.Models
{
    public class SeaDTO : BaseEntityDTO
    {
        public Int32 ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
        public List<OscillatorDTO> Oscillators { get; set; }
        public List<IsleDTO> Isles { get; set; }
    }
}
