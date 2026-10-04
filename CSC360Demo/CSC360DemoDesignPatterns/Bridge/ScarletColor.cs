using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Bridge {
    public class ScarletColor : IColor {
        public string ApplyColor() {
            return "Scarlet";
        }
    }
}
