namespace UltraSoundWeb.Entities
{
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public long? SpecializedId { get; set; }
        public Specialized Specialized { get; set; }
        public long? UserId { get; set; }
        public User User { get; set; }

        public ICollection<UltraSoundResult> UltraSoundResults { get; set; }
    }
}
