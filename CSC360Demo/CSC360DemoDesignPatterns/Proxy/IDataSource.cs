using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Proxy;
public interface IDataSource {
  public string SomeVeryExpensiveDataActivity();
  bool Dirty();
}
