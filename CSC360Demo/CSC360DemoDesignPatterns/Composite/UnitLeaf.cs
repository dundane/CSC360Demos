using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Composite {
    public class UnitLeaf : IGameUnit {
        public UnitLeaf() { 
            UnitName = Guid.NewGuid().ToString();
        }
        public string UnitName { get; set; }

        public void Attack() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{UnitName} Unit Attacking");
            Console.ResetColor();
        }
    }
}
