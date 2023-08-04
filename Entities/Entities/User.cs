using Entities.Enums;

namespace Entities.Entities
{
    public class User : BaseEntity
    {
        public UserTypeEnum UserType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
