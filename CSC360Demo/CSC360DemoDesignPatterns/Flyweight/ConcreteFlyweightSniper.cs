using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Flyweight;
public class ConcreteFlyweightSniper : IFlyweightSoldier {

  public ConcreteFlyweightSniper() {
    OffensiveStrength = 2;
    DefensiveStrength = 1;
  }
  public int OffensiveStrength { get; set; }
  public int DefensiveStrength { get; set; }
}
