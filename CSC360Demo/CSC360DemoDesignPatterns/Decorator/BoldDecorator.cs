using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Decorator;
public class BoldDecorator : TextDecoratorBase {
  public BoldDecorator(IText text) : base(text) {
  }

  public override String Render() {
    return $"<b>{base.Render()}</b>";
  }
}
