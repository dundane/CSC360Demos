using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Flyweight;
public class ConcreteFlyweightInfantry : IFlyweightSoldier {

  public ConcreteFlyweightInfantry() { 
    OffensiveStrength = 1;
    DefensiveStrength = 2;
  }
  public int OffensiveStrength { get; set; }
  public int DefensiveStrength { get;set; }
}
