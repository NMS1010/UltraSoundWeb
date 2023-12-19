namespace UltraSoundWeb.Models
{
    public class PatientVM
    {
        public long Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string InsuranceNumber { get; set; }
    }
}
