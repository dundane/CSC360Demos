using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Bridge {
    public class Triangle : IShape {
        private IColor color;
        public Triangle(IColor color) {
            this.color = color;
        }
        public void Draw() {
            Console.WriteLine($"Triangle drawn in {color.ApplyColor()} color.");
        }
    }
}
