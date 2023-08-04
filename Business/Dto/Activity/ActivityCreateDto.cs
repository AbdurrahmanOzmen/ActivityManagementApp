using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.Activity
{
   public class ActivityCreateDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

    }
}
