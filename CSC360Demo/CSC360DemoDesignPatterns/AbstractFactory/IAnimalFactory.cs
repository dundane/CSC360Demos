using CSC360DemoDesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public interface IAnimalFactory {
        IReadOnlyList<string> AnimalTypes { get; }
        IAnimal CreateAnimal(string animalType);
    }
}
