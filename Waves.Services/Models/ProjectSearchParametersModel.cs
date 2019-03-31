using System;
using Waves.Services.Models.Shared;

namespace Waves.Services.Models
{
    public class ProjectSearchParametersModel : ItemPageSearchBaseModel
    {
        public Int32? ProjectId { get; set; }
        public Int32? UserId { get; set; }
        public String SearchTerm { get; set; }
        public Boolean IsActive { get; set; }
    }
}
