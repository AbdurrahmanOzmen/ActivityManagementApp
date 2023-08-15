using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dto.User
{
   public class UserDto
    {
        public int Id { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
