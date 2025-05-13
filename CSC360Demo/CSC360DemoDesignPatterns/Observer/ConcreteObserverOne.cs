using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Observer;
public class ConcreteObserverOne : ISubscriber {
  private Guid id;
  public ConcreteObserverOne(){
    id = Guid.NewGuid();
  }
  public void UpdateState(String newState) {
    if (newState != "StateTwo") {
      Console.WriteLine($"Observer One ID {id.ToString()} accepted state {newState}");
    } else {
      Console.WriteLine($"Observer One ID {id.ToString()} ignored state {newState}");
    }
  }
}
