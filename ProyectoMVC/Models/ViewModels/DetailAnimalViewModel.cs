namespace ProyectoMVC.Models.ViewModels
{
    public class DetailAnimalViewModel
    {
        public Animal AnimalDetail { get; set; } = new Animal();
        public TipoAnimal TipoAnimal { get; set; } = new TipoAnimal();

    }
}
