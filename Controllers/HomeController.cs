using Microsoft.AspNetCore.Mvc;
using OtarioLearning.Models;
using OtarioStudy.Services.Implementation;
using OtarioStudy.Services.Interfaces;
using System.Diagnostics;

namespace OtarioLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepository Repository;
        public HomeController(ILogger<HomeController> logger, IRepository Repository)
        {
            this.Repository = Repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
