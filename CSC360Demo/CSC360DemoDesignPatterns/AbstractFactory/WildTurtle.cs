using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC360DemoDesignPatterns.Factory;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class WildTurtle : IAnimal {
        public string Speak() {
            return "Screech!!!!";
        }
    }
}
