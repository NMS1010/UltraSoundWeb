namespace UltraSoundWeb.Entities
{
    public class UltraSoundSample : BaseEntity
    {
        public string SampleName { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string DefaultDiagnostic { get; set; }
        public string DefaultConclusion { get; set; }
        public string DefaultRecommendation { get; set; }
        public string ResultDescription { get; set; }
        public ICollection<UltraSoundResult> UltraSoundResults { get; set; }
    }
}
