
using OtarioStudy.BacgroundTasks;

namespace OtarioLearning.BacgroundTasks
{
    public class HostedServiceBackground : IHostedService
    {
        ICleanDownloadsFolder CleanFolders;
        IDailyTopicWordsService DailyTopicWords;
        public HostedServiceBackground(ICleanDownloadsFolder CleanFolders, IDailyTopicWordsService DailyTopicWords)
        {
            this.DailyTopicWords = DailyTopicWords;
            this.CleanFolders = CleanFolders;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            DailyTopicWords.Start();
            CleanFolders.Clean(null);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
