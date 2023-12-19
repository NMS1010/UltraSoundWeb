namespace UltraSoundWeb.Entities
{
    public class UltraSoundResult : BaseEntity
    {
        public DateTime Date { get; set; }
        public string No { get; set; }

        public long? UltraSoundSampleId { get; set; }
        public UltraSoundSample UltraSoundSample { get; set; }

        public long DoctorUltraSoundId { get; set; }

        public long? DoctorSpecifyId { get; set; }
        public Doctor DoctorSpecify { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string ResultDescription { get; set; }
        public string Conclusion { get; set; }

        public ICollection<ResultImage> ResultImages { get; set; }
    }
}
