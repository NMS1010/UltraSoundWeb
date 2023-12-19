namespace UltraSoundWeb.Models
{
    public class UltraSoundSampleVM
    {
        public long Id { get; set; }
        public string SampleName { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string DefaultDiagnostic { get; set; }
        public string DefaultConclusion { get; set; }
        public string DefaultRecommendation { get; set; }
        public string ResultDescription { get; set; }
    }
}
