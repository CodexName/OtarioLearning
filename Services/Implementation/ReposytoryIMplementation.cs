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
   
    }

}
