using OtarioLearning.BacgroundTasks;
using OtarioStudy.BacgroundTasks;
using OtarioStudy.Services.Implementation;
using OtarioStudy.Services.Interfaces;

namespace OtarioLearning.ServiceCollection
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection Services (this IServiceCollection services)
        {
            services.AddTransient<IRepository, ReposytoryIMplementation>();
            services.AddTransient<IDailyTopicWordsService,DailyTopicWordsImplementation>();
            services.AddTransient<ICleanDownloadsFolder,CleanDownloadsFolder>();
  /*          services.AddHostedService<DailyTopicWordsImplementation>();*/
            services.AddHostedService<CleanDownloadsFolder>();
            return services; 
        }
    }
}
