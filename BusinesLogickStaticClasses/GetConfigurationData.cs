using Microsoft.Extensions.Configuration;

namespace OtarioLearning.BusinesLogickStaticClasses
{
    public static class GetConfigurationData
    {
        public static IConfigurationRoot? ConfigurationFile = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
        public static string GetAzureBlobConnectionStr()
        {
            string BlobConnectionString = ConfigurationFile.GetValue<string>("ConnectionStrBlobStore");
            return BlobConnectionString;
        }
    }
}
