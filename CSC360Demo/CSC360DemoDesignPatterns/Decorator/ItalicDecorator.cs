using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Decorator;
public class ItalicDecorator : TextDecoratorBase {
  public ItalicDecorator(IText text) : base(text) {
  }

  public override String Render() {
    return $"<i>{base.Render()}</i>";
  }
}
