using CSC360DemoDesignPatterns.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Factory {
    public class PetAnimalFactory : IAnimalFactory {
        private readonly AnimalFactoryTypeCatalog catalog = new(typeof(PetAnimalFactory));

        public IReadOnlyList<string> AnimalTypes => catalog.Names;

        public IAnimal CreateAnimal(string animalType) => catalog.Create(animalType);
    }
}
