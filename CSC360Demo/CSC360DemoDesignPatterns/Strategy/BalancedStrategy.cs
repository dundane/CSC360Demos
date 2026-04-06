using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Strategy {
    public class BalancedStrategy : IAIStrategy {
        public void Attack() {
            Console.WriteLine("Attacking with half units and keeping back half for defense.");
        }
    }
}
