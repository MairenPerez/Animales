using Animales.DAL;
using Microsoft.AspNetCore.Mvc;
using ProyectoMVC.Models;
using ProyectoMVC.Models.ViewModels;
using System.Diagnostics;

namespace ProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AnimalDAL dal = new AnimalDAL();
            AnimalViewModel animalViewModel = new AnimalViewModel
            {
                Animales = dal.GetAll()
            };

            return View(animalViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AnimalDetail(int id)
        {
            return RedirectToAction("Details", "Animal", new { id });
        }

        [HttpPost]
        public IActionResult AddAnimal()
        {
            return RedirectToAction("AddAnimal", "Animal");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
