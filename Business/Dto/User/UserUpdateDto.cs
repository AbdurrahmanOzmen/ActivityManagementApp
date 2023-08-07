using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.User
{
    public class UserUpdateDto : UserCreateDto
    {
        public int Id { get; set; }
    }
}
