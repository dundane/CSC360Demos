using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Proxy;
public class ActualSource : IDataSource {
  public string SomeVeryExpensiveDataActivity() {
    return $"Get Fancy Smancy Data {Guid.NewGuid()}";
  }
  public bool Dirty() { 
    Random rnd = new Random();
    if (rnd.Next(1, 5) == 1) {
      return true;
    }
    return false;
  }
}
