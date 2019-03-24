using System;

namespace Waves.Domain.Models.Base
{
    public interface IBaseEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
