using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Flyweight;
public class CombatUnit {
  public CombatUnit(string name, IFlyweightSoldier soldierType) { 
  Name = name;
    SoldierTypeCommon = soldierType;
  }
  public string Name { get; set; }
  public IFlyweightSoldier SoldierTypeCommon { get; set; }
}
