using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Observer;
public interface IPublisher {
  public void RegisterSubscriber(ISubscriber subscriber);
  public void UnregisterSubscriber(ISubscriber subscriber);
  public void Publish(String newState);
}
