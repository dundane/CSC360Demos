using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Composite {
    internal class UnitGroup : IComposite {
        private List<IGameUnit> units;
        public UnitGroup() { 
            units = new List<IGameUnit>();
            UnitName = Guid.NewGuid().ToString();
        }
        public string UnitName { get; set; }

        public void Add(IGameUnit unit) {
            units.Add(unit);
        }

        public void Attack() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{UnitName} Unit Group Attacking!");
            foreach (IGameUnit unit in units) {
                unit.Attack();
            }
            Console.ResetColor();
        }

        public IGameUnit GetChild(int index) {
            return units[index];
        }

        public void Remove(IGameUnit unit) {
            units.Remove(unit);
        }
    }
}
