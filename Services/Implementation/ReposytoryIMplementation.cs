using Microsoft.EntityFrameworkCore;
using OtarioStudy.DataBaseContext;
using OtarioStudy.Models;
using OtarioStudy.Services.Interfaces;
using Serilog;

namespace OtarioStudy.Services.Implementation
{
    public class ReposytoryIMplementation : IRepository
    {
        OtarioDbContext Context;
        public ReposytoryIMplementation(OtarioDbContext Context)
        {
            this.Context = Context; 
        }

        public async Task<List<WordsTopic>> GetDailyWords(string UserName)
        {

            var Topic = Context.Users
                 .Where(u => u.UserName == "Smit")
                 .Select(u => u.TodaysTopic)
                .FirstOrDefault();

            var DailyWords = Context.WordsTopics
                .Include(x => new { x.Words.Word, x.Words.WordTranslation })
                .Where(x => x.Topic == Topic)
                .Take(10)
                .OrderBy(x => x.Words)
                .ToList();
            return DailyWords;
        }
    }

}
