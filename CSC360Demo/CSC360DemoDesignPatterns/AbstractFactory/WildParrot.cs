using CSC360DemoDesignPatterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.AbstractFactory;
public class WildParrot : IAnimal {
    string IAnimal.Speak() {
        return "I am going to eat you!!!!";
    }
}
