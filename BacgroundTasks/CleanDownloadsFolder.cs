namespace OtarioLearning.BacgroundTasks
{
    public class CleanDownloadsFolder : ICleanDownloadsFolder
    {
        public void Clean(object obj)
        {
            string pathToFolder = "D:\\DotnetProject\\OtarioLearning\\Downloads";
            string[] files = Directory.GetFiles(pathToFolder);
            foreach (var item in files)
            {
                File.Delete(item);
                Console.WriteLine("Delete");
            }        
        }
        public void Start()
        {
            TimerCallback timerCallBack = new TimerCallback(Clean);
            int timeInterval = 10000;
            Timer timer = new Timer(timerCallBack,null,6000,timeInterval);
        }
    }
}
