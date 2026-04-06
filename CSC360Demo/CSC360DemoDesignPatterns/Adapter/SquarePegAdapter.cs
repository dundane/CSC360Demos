using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Adapter {
    public class SquarePegAdapter : IRoundPeg {
        private ISquarePeg squarePeg;
        public SquarePegAdapter(ISquarePeg squarePeg) { 
        this.squarePeg = squarePeg;
        }

        public double GetRadius() {
            return squarePeg.GetWidth() * Math.Sqrt(2) / 2;
        }
    }
}
