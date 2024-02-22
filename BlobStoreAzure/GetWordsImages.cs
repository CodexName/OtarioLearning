using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using OtarioLearning.BusinesLogickStaticClasses;
using OtarioStudy.Models;
using Serilog;
using System.Text;

namespace OtarioLearning.BlobStoreAzure
{
    public static class GetWordsImages
    {
        public static List<string> GetImages(List<WordsTopic> topicWords)
        {
            string AzureBlobConnectionString = GetConfigurationData.GetAzureBlobConnectionStr();
            var blobServiceClient = new BlobServiceClient(AzureBlobConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("otariolearningimagewords");
            List<string> pathToImageToWords = new List<string>();
            try
            {
                foreach (var word in topicWords)
                {
                    string filename = word.Words.Word + "Image.jpg";
                    BlobClient blobClient = containerClient.GetBlobClient(filename);
                    string PathToImage = Path.Combine(Environment.CurrentDirectory, "Downloads",filename);
                    blobClient.DownloadTo(PathToImage);
                    pathToImageToWords.Add(PathToImage);
                }
            }
            catch (Exception exeption)
            {
                Log.Error( $"Error - {exeption.Message} date: {DateTime.Now}");
            }
           
            return pathToImageToWords;
       
        }
    }
}
