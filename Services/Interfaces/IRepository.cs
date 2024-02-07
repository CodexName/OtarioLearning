using OtarioStudy.Models;

namespace OtarioStudy.Services.Interfaces
{
    public interface IRepository
    {
        List<User> GetAllUsers();
        List<WordsTopic> GetAllTopics();
        Task UserDailyTopicUptade(string Topic);
    }
}