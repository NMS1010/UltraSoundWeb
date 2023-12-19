namespace UltraSoundWeb.Models
{
    public class InfoVM
    {
        public long Id { get; set; }
        public string TitleName { get; set; }
        public string LogoImage { get; set; }
        public IFormFile Image { get; set; }
        public string TitleDetail { get; set; }
        public string TitleResult { get; set; }
        public string TopicInfo { get; set; }
        public string TopicDescriptionResult { get; set; }
        public string TopicImage { get; set; }
        public string TopicConclusion { get; set; }
        public string TopicRecommendation { get; set; }
        public string Note { get; set; }
    }
}
