using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Mediator;
public class ConcreteColleague : IColleague {

  private readonly IChatMediator mediator;
  private readonly string name;

  public ConcreteColleague(IChatMediator mediator, string name) {
    this.mediator = mediator;
    this.name = name;
  }

  public void Receive(string message) {
    Console.WriteLine($"{name} : {message}");
  }

  public void Send(string message) {
    mediator.SendMessage(message, this);
  }
}
