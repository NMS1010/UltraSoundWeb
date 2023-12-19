using UltraSoundWeb.Common.Enums;

namespace UltraSoundWeb.Models
{
    public class UserVM
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public ROLE Role { get; set; }
    }
}
