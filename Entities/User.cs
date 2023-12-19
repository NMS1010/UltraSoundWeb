using UltraSoundWeb.Common.Enums;

namespace UltraSoundWeb.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ROLE Role { get; set; }

        public Doctor Doctor { get; set; }
    }
}
