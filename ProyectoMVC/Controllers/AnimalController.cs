using Animales.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoMVC.Models;
using ProyectoMVC.Models.ViewModels;

namespace ProyectoMVC.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel vm = new DetailAnimalViewModel();

            vm.AnimalDetail = dal.GetById(id);

            if (vm.AnimalDetail == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            AddAnimalViewModel vm = new AddAnimalViewModel
            {
                TiposDeAnimales = GetTiposDeAnimales()
            };

            return View(vm); 
        }



        // POST: Guardar el nuevo animal
        [HttpPost]
        public IActionResult AddAnimal(AddAnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simula el guardado del animal en tu base de datos.
                AnimalDAL dal = new AnimalDAL();
                dal.AddAnimal(model);

                // Redirige al índice si todo es válido.
                return RedirectToAction("AddAnimal");
            }


            // Si el modelo no es válido, vuelve a cargar los tipos de animales.
            model.TiposDeAnimales = GetTiposDeAnimales();
            return View(model);
        }

        private IEnumerable<SelectListItem> GetTiposDeAnimales()
        {
            // Este método debe obtener los tipos de animales desde tu base de datos.
            return new List<SelectListItem>
                            {
                                new SelectListItem { Value = "1", Text = "Perro" },
                                new SelectListItem { Value = "2", Text = "Gato" },
                                new SelectListItem { Value = "3", Text = "Ave" }
                            };
        }
    }
}
