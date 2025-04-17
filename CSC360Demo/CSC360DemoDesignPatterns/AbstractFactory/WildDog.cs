using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC360DemoDesignPatterns.Factory;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class WildDog : IAnimal {
        public string Speak() {
            return "Growl!!!!";
        }
    }
}
