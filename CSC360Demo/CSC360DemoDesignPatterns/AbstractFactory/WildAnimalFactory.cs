using CSC360DemoDesignPatterns.Factory;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class WildAnimalFactory : IAnimalFactory {
        private readonly AnimalFactoryTypeCatalog catalog = new(typeof(WildAnimalFactory), "Wild");

        public IReadOnlyList<string> AnimalTypes => catalog.Names;

        public IAnimal CreateAnimal(string animalType) => catalog.Create(animalType);
    }
}