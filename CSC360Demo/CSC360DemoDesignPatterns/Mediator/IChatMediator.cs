using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Mediator;
public interface IChatMediator {
  void SendMessage(string message, IColleague user);
  void AddUser(IColleague user);

}
