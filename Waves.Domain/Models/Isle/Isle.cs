using System;
using System.ComponentModel.DataAnnotations.Schema;
using Waves.Domain.Models.Base;

namespace Waves.Domain.Models
{
    public class Isle : BaseEntity
    {
        public String Type { get; set; }
        public Int32 Column { get; set; }
        public Int32 Row { get; set; }
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }

        [ForeignKey("Sea")]
        public Int32 SeaId { get; set; }
        public Sea Sea { get; set; }
    }
}
