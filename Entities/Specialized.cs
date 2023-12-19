namespace UltraSoundWeb.Entities
{
    public class Specialized : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
