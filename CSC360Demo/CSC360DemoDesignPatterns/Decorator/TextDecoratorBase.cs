using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Decorator;
public class TextDecoratorBase : IText {

  protected IText text;

  public TextDecoratorBase(IText text) { 
    this.text = text;
  }

  public virtual string Render() {
    return text.Render();
  }
}
