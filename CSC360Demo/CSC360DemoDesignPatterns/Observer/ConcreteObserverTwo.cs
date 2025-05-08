using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Observer;
public  class ConcreteObserverTwo : ISubscriber {
  private Guid id;
  public ConcreteObserverTwo() {
    id = Guid.NewGuid();
  }
  public void UpdateState(String newState) {
    if (newState != "StateOne") {
      Console.WriteLine($"Observer Two ID {id.ToString()} accepted state {newState}");
    } else {
      Console.WriteLine($"Observer Two ID {id.ToString()} ignored state {newState}");
    }
  }
}
