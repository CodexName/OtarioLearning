using Microsoft.AspNetCore.Mvc;
using OtarioLearning.BlobStoreAzure;
using OtarioLearning.BusinesLogickStaticClasses;
using OtarioLearning.Models.DtoModels;
using OtarioStudy.Services.Interfaces;

namespace OtarioLearning.Controllers
{
    public class StudyWordsController : Controller
    {
        IRepository Repository;
        public StudyWordsController(IRepository Repository)
        {
            this.Repository = Repository;
        }
        public IActionResult StudyWordsView() => View("Views\\StudyWords\\StudyWordsView.cshtml");
        [HttpGet]
        public async Task<IActionResult> StartLesson()
        {
            string TodayTopic =  "Smit" /* HttpContext.Request.Cookies[AllCookieKeys.UserNameCookie]*/;
            var wordsList = await Repository.GetDailyWords(TodayTopic);
            var pathToImageList = GetWordsImages.GetImages(wordsList);
            var DtoWordsLIst = new List<DtoWordsLesson>();
            foreach (var word in wordsList)
            {
                foreach (var imagePath in pathToImageList)
                {
                    var dtoWord = new DtoWordsLesson
                    {
                        ImagePath = imagePath,
                        Translate = word.Words.WordTranslation,
                        Word = word.Words.Word
                    };
                    DtoWordsLIst.Add(dtoWord);
                }
            }
            return View("Views\\StudyWords\\StartLessonView.cshtml",DtoWordsLIst);
        }
    }
}
