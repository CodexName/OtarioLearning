namespace OtarioStudy.Models
{
    public class WordsTopic
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public int BelongWordsCount { get; set; }
        public ICollection<User> Users { get; set; } 
    }
}
