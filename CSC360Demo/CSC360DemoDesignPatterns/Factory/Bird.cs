using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Factory {
    public class Bird : IAnimal {
        string IAnimal.Speak() {
            return "Tweet!";
        }
    }
}
