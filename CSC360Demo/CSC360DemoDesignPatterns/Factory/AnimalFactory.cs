using CSC360DemoDesignPatterns.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Factory {
    public class PetAnimalFactory : IAnimalFactory {
        public IAnimal CreateAnimal(string animalType) {
            switch (animalType.ToUpper()) {
                case "DOG":
                    return new Dog();
                case "CAT":
                    return new Cat();
                case "BIRD":
                    return new Bird();
                case "TURTLE":
                    return new Turtle();
                default:
                    throw new ArgumentException("Unkinow Animal Type");
            }
        }
    }
}
