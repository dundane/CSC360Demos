using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Bridge {
    public class Cross : IShape {
        private IColor color;
        public Cross(IColor color) {
            this.color = color;
        }
        public void Draw() {
            Console.WriteLine($"Cross drawn in {color.ApplyColor()} color.");
        }
    }
}
