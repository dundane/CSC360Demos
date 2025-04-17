using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State;
public class Context {
  IBoomBoxSource source;
  public Context(IBoomBoxSource initialSource = null) {
    source = initialSource;
  }

  public string PlayMusic() {
    if (source == null) {
      return "No Source Selected";
    } else
      return $"Now Playing....{source.PlayMuisc()} on {source.Source()}";
  }

  public void SetContext(IBoomBoxSource newSource) { 
    source = newSource;
  }
}
