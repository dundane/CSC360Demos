using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Adapter {
    public class RoundPeg : IRoundPeg {

        private double radius;
        public RoundPeg(double radius) { 
            this.radius = radius;
        }
        public double GetRadius() {
            return radius;
        }
    }
}
