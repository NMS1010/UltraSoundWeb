namespace UltraSoundWeb.Models
{
    public class DoctorVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SpecializedId { get; set; }
        public SpecializedVM Specialized { get; set; }
        public UserVM User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
