using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Decorator;
public class PlainText : IText {
  public string Render() {
    return "Sup Peeps!";
  }
}
