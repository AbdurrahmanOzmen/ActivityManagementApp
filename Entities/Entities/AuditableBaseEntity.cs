using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class AuditableBaseEntity :BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedUserId { get; set; }
    }
}
