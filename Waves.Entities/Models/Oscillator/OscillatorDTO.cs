using System;
using Waves.Entities.Models.Base;

namespace Waves.Entities.Models.Oscillator
{
    public class OscillatorDTO : BaseEntityDTO
    {
        public Double Amplitude { get; set; }
        public Int32 Row { get; set; }
        public Int32 Column { get; set; }
        public Int32 SeaId { get; set; }
        public SeaDTO Sea { get; set; }
    }
}
