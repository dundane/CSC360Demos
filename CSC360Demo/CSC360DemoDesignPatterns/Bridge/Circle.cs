using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Bridge;
public class Circle : IShape {
  private IColor color;
  public Circle(IColor color) { 
    this.color = color;
  }
  public void Draw() {
    Console.WriteLine($"Circle drawn in {color.ApplyColor()} color.");
  }
}
