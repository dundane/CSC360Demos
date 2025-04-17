using CSC360DemoDesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class AnimalFactoryAbstract {
        public IAnimalFactory GetFactory(string factoryType) {
            switch (factoryType.ToUpper()) {
                case "WILD":
                    return new WildAnimalFactory();
                default:
                    return new PetAnimalFactory();
            }
        }
    }
}
