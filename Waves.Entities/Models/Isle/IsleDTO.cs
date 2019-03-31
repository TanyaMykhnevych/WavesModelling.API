using System;
using Waves.Entities.Models.Base;

namespace Waves.Entities.Models.Isle
{
    public class IsleDTO : BaseEntityDTO
    {
        public IsleType Type { get; set; }
        public Int32 Column { get; set; }
        public Int32 Row { get; set; }
        public Int32 ColumnTo { get; set; }
        public Int32 RowTo { get; set; }
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public Int32 SeaId { get; set; }
        public SeaDTO Sea { get; set; }
    }
}
