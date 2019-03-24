using System;
using Waves.Domain.Models.Base;

namespace Waves.Domain.Identity
{
    public class AppRoleFeature : BaseEntity
    {
        public Int32 AppRoleId { get; set; }
        public Int32 AppFeatureId { get; set; }
        public AppRole AppRole { get; set; }
        public AppFeature AppFeature { get; set; }
    }
}
