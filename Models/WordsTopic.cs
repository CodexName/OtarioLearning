namespace OtarioStudy.Models
{
    public class WordsTopic
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public int BelongWordsCount { get; set; }
        public int ForeignWordsId { get; set; }
        public Words Words { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
