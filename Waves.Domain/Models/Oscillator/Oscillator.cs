using System;
using System.ComponentModel.DataAnnotations.Schema;
using Waves.Domain.Models.Base;

namespace Waves.Domain.Models
{
    public class Oscillator : BaseEntity
    {
        public Double Amplitude { get; set; }

        public Int32 Row { get; set; }
        public Int32 Column { get; set; }

        [ForeignKey("Sea")]
        public Int32 SeaId { get; set; }
        public Sea Sea { get; set; }
    }
}
