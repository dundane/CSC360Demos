using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Observer;
public  class ConcreteObserverThree : ISubscriber {
  private Guid id;
  public ConcreteObserverThree() {
    id = Guid.NewGuid();
  }
  public void UpdateState(String newState) {
    if (newState != "StateThree") {
      Console.WriteLine($"Observer Three ID {id.ToString()} accepted state {newState}");
    } else {
      Console.WriteLine($"Observer Three ID {id.ToString()} ignored state {newState}");
    }
  }
}
