using OtarioStudy.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace OtarioStudy.BacgroundTasks
{
    public class DailyTopicWordsImplementation  : IDailyTopicWordsService
    {
        IRepository Repository;
        public DailyTopicWordsImplementation(IRepository Repository)
        {
            this.Repository = Repository;
        }
        public void GetDailyTopic(object obj)
        {
            var UsersList = Repository.GetAllUsers();
            var AllTopics = Repository.GetAllTopics();
            foreach (var User in UsersList)
            {
                foreach (var PassedTopic in User.PassedTopics)
                {
                    foreach (var Topic in AllTopics)
                    {
                        if (PassedTopic.Topic == Topic.Topic)
                        {
                            continue;
                        }
                        else if (PassedTopic.Topic != Topic.Topic)
                        {
                            Repository.UserDailyTopicUptade(Topic.Topic);                 
                            break;
                        }
                    }
                }
            }
        }
        public void Start()
        {
            TimerCallback timerCallback = new TimerCallback(GetDailyTopic);
            Timer timer = new Timer(timerCallback,null,0, 86400000);
        }
    }
}