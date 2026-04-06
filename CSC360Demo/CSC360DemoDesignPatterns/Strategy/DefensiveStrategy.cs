using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Strategy {
    public class DefensiveStrategy : IAIStrategy {
        public void Attack() {
            Console.WriteLine("Attaking with 10% of available units, keeping back 90% for defense");
        }
    }
}
