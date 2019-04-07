using System;

namespace Waves.Entities.Models.Base
{
    public class BaseEntityDTO
    {
        public Int32 Id { get; set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
        public Boolean IsDeleted { get; private set; }
    }
}
