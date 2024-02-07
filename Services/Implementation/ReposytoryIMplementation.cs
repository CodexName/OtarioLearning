using Microsoft.EntityFrameworkCore;
using OtarioStudy.DataBaseContext;
using OtarioStudy.Models;
using OtarioStudy.Services.Interfaces;

namespace OtarioStudy.Services.Implementation
{
    public class ReposytoryIMplementation : IRepository
    {
        OtarioDbContext Context;
        public ReposytoryIMplementation(OtarioDbContext Context)
        {
            this.Context = Context; 
        }
        public List<WordsTopic> GetAllTopics()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task UserDailyTopicUptade(string Topic)
        {
            throw new NotImplementedException();
        }
    }

}
