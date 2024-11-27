using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoMVC.Models.ViewModels
{
    public class AddAnimalViewModel
    {
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public int TipoAnimalId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public IEnumerable<SelectListItem> TiposDeAnimales { get; set; }
    }
}
