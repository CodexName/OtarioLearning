using Microsoft.AspNetCore.Mvc;
using OtarioLearning.BlobStoreAzure;

namespace OtarioLearning.Controllers
{
    public class LearningWordsController : Controller
    {
        [HttpGet]
        public IActionResult StartLesson ()
        {
            List<string> words = new List<string>()
            {
               "Pensil","Pen","Book"
            };
            var ListPathToWordsImages = GetVideoSourceGrammarSection.GetImages(words,"Alex");
            return Ok(ListPathToWordsImages);
        }
    }
}
