namespace CSC360DemoDesignPatterns.Flyweight;
public class FlyweightFactory {
  Dictionary<String, IFlyweightSoldier> soldierTypes;
  public FlyweightFactory() { 
    soldierTypes = new Dictionary<String, IFlyweightSoldier>();
  }

  public IFlyweightSoldier GetFlyweightSoliderType(String type) {
    if (!soldierTypes.ContainsKey(type)) { 
      CreateSoldierType(type);
    }
    return soldierTypes[type];
  }

  private void CreateSoldierType(String type) {
    switch (type) {
      case "Sniper":
          soldierTypes.Add("Sniper", new ConcreteFlyweightSniper());
        break;
      case "Infantry":
        soldierTypes.Add("Infantry", new ConcreteFlyweightInfantry());
        break;
      default:
        if (!soldierTypes.ContainsKey("Infantry")) {
          soldierTypes.Add("Infantry", new ConcreteFlyweightInfantry());
        }
          soldierTypes.Add(type, soldierTypes["Infantry"]);
        break;

    }
  }
}
