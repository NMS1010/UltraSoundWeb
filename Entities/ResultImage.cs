namespace UltraSoundWeb.Entities
{
    public class ResultImage : BaseEntity
    {
        public string Path { get; set; }
        public long? UltraSoundResultId { get; set; }
        public UltraSoundResult UltraSoundResult { get; set; }
    }
}
