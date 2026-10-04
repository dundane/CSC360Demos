using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Mediator;
public class ConcreteMediator : IChatMediator {

  private readonly List<IColleague> colleagues;

  public ConcreteMediator() { 
    colleagues = new List<IColleague>();
  }

    public void Register(IColleague colleague) {
    if (!colleagues.Contains(colleague)) {
      colleagues.Add(colleague);
    }
  }

  public void RelayMessage(string message, IColleague sender) {
    foreach (var colleague in colleagues) {
      if (colleague != sender) {
        colleague.Receive(message);
      }
    }
  }

    public void SendMessage(string message, IColleague user) {
        Console.WriteLine($"{user.Name} sends message: {message}");
        RelayMessage(message, user);
    }
}
