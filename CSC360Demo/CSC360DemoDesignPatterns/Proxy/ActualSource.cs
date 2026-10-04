namespace CSC360DemoDesignPatterns.Proxy;
public class ActualSource : IDataSource {
  private static readonly Random random = new Random();

  public string SomeVeryExpensiveDataActivity() {
    return $"Get Fancy Smancy Data {Guid.NewGuid()}";
  }
  public bool Dirty() { 
    return random.Next(1, 5) == 1;
  }
}


