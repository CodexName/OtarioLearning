namespace OtarioStudy.Models
{
    public class Words
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public DateTime DateTime { get; set; }
        public WordsTopic WordsTopics { get; set; }
    }
}
