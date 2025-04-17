using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Factory {
    public class Dog : IAnimal {
        public string Speak() {
            return "Bark Bark";
        }
    }
}
