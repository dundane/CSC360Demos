using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Mediator;
public interface IColleague {
  void Send(string message);
  void Receive(string message);

}
