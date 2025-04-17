using CSC360DemoDesignPatterns.Factory;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class WildAnimalFactory : IAnimalFactory {
        public IAnimal CreateAnimal(string animalType) {
            switch (animalType.ToUpper()) {
                case "DOG":
                    return new WildDog();
                case "CAT":
                    return new WildCat();
                case "BIRD":
                    return new WildBird();
                case "TURTLE":
                    return new WildTurtle();
                default:
                    throw new ArgumentException("Unkinow Animal Type");

            }
        }
    }
}