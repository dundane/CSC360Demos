using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Adapter {
    public class SquarePeg : ISquarePeg {

        private double width;
        public SquarePeg(double width) {
            this.width = width;
        }

        public double GetWidth() {
            return width;
        }
    }
}
