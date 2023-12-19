namespace UltraSoundWeb.Models
{
    public class UltraSoundResultVM
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string No { get; set; }

        public long UltraSoundSampleId { get; set; }
        public UltraSoundSampleVM UltraSoundSample { get; set; }

        public long DoctorUltraSoundId { get; set; }
        public DoctorVM DoctorUltraSound { get; set; }

        public long DoctorSpecifyId { get; set; }
        public DoctorVM DoctorSpecify { get; set; }

        public long PatientId { get; set; }
        public PatientVM Patient { get; set; }

        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public string ResultDescription { get; set; }
        public string Conclusion { get; set; }

        public List<IFormFile> ResultImages { get; set; }

        public List<ResultImageVM> Images { get; set; }
    }
    public class ResultImageVM
    {
        public long Id { get; set; }
        public string Path { get; set; }
    }
}
