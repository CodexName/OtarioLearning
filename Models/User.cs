namespace OtarioStudy.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<WordsTopic> PassedTopics { get; set; }
        public WordsTopic TodaysTopic { get; set; }
    }
}
