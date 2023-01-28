using System.Diagnostics;
using FinalExam.Data;
using FinalExam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                works = applicationDbContext.Works.ToList()
            };
            return View(homeViewModel);
        }
    }
}