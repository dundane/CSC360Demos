using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Observer;

public class ConcretePublisher: IPublisher {
  private List<ISubscriber> subscribers;
  public ConcretePublisher() {
    subscribers = new List<ISubscriber>();
  }

  public void Publish(String newState) {
    foreach (ISubscriber subscriber in subscribers) {
      subscriber.UpdateState(newState);
    }
  }

  public void RegisterSubscriber(ISubscriber subscriber) {
    if (!subscribers.Contains(subscriber)) {
      subscribers.Add(subscriber);
    }
  }

  public void UnregisterSubscriber(ISubscriber subscriber) {
    if (subscribers.Contains(subscriber)) {
      subscribers.Remove(subscriber);
    }
  }
}
