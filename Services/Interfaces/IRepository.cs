using OtarioStudy.Models;

namespace OtarioStudy.Services.Interfaces
{
    public interface IRepository
    {
       Task<List<WordsTopic>> GetDailyWords(string Topic);
    }
}