using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Strategy {
    public class AgressiveStrategy : IAIStrategy {
        public void Attack() {
            Console.WriteLine("Attacking with everything!!!!!");
        }
    }
}
