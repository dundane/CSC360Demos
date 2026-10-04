using CSC360DemoDesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.AbstractFactory {
    public class WildLizard : IAnimal {
        public string Speak() {
            return "Hisss";
        }
    }
}
