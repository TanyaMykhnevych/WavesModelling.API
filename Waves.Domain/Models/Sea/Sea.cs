using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Waves.Domain.Models.Base;

namespace Waves.Domain.Models
{
    public class Sea : BaseEntity
    {
        public Int32 N { get; set; }

        [ForeignKey("Project")]
        public Int32 ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Oscillator> Oscillators { get; set; }
        public List<Isle> Isles { get; set; }
    }
}
