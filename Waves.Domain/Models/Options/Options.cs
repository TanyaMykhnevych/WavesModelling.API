using System;
using System.ComponentModel.DataAnnotations.Schema;
using Waves.Domain.Models.Base;

namespace Waves.Domain.Models
{
    public class Options : BaseEntity
    {
        public Int32 D { get; set; }
        public Int32 N { get; set; }
        public Single Omega { get; set; }
        public Double W { get; set; }
        public Int32 R { get; set; }
        public Int32 KvisRange { get; set; }

        [ForeignKey("Project")]
        public Int32 ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
