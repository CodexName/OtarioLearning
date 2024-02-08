
namespace OtarioLearning.BacgroundTasks
{
    public class CleanDownloadsFolder : ICleanDownloadsFolder , IHostedService
    {
        private Timer timer;
        public void Clean(object obj)
        {
            string pathToFolder = Path.Combine(Environment.CurrentDirectory, "Downloads");
            string[] files = Directory.GetFiles(pathToFolder);
            if (files.Length != 0)
            {
                foreach (var item in files)
                {
                    File.Delete(item);
                    Console.WriteLine("Delete");
                }
            }
            else
            {
                Console.WriteLine("Empty");
            }
        }

        public void Start()
        {
            TimerCallback timerCallBack = new TimerCallback(Clean);
            int timeInterval = 1000 * 60 * 60 * 24;
            timer = new Timer(timerCallBack, null, 0, timeInterval);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
