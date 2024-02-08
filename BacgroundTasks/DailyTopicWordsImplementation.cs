using Microsoft.EntityFrameworkCore;
using OtarioStudy.DataBaseContext;
using System;

namespace OtarioStudy.BacgroundTasks
{
    public class DailyTopicWordsImplementation : IDailyTopicWordsService, IHostedService
    {        
        public void GetDailyTopic(object obj)
        {
            var options = new DbContextOptionsBuilder<OtarioDbContext>().UseSqlite("ConnectionStr").Options;
            using (OtarioDbContext Context = new OtarioDbContext(options))
            {
                var UsersList = Context.Users.ToList();
                var AllTopics = Context.WordsTopics.ToList();
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
                                Context.Users.ExecuteUpdate(x => x.SetProperty(x => x.TodaysTopic, Topic.Topic));
                                break;
                            }
                        }
                    }
                }
            }
           
        }
        public void Start()
        {
            TimerCallback timerCallback = new TimerCallback(GetDailyTopic);
            Timer timer = new Timer(timerCallback, null, 20000, 86400000);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}