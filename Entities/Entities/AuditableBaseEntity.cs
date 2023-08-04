using System;

namespace Entities.Entities
{
    public class AuditableBaseEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
    }
}
