using Microsoft.EntityFrameworkCore;
using OtarioStudy.DataBaseContext;
using Serilog;
using System;

namespace OtarioStudy.BacgroundTasks
{
    public class DailyTopicWordsImplementation : IDailyTopicWordsService, IHostedService
    {        
        public void GetDailyTopic(object obj)
        {
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            string connectionString = config.GetConnectionString("ConnectionStr");
            var options = new DbContextOptionsBuilder<OtarioDbContext>().UseSqlServer(connectionString).Options;
            try
            {
                using (OtarioDbContext Context = new OtarioDbContext(options))
                {
                    var UsersList = Context.Users.Include(x => x.PassedTopics).ToList();
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
            catch (Exception exeption)
            {
                Log.Error($"Error {exeption.Message} - Time {DateTime.Now}");
            }
        }
        public void Start()
        {
            TimerCallback timerCallback = new TimerCallback(GetDailyTopic);
            Timer timer = new Timer(timerCallback, null, 200, 8000);
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