

namespace CSC360DemoDesignPatterns.Proxy;
public class ProxySource : IDataSource {
  private IDataSource source;
  private string cache = "";
  public ProxySource(IDataSource sourceToProxy) {
    source = sourceToProxy;
  }

  public string SomeVeryExpensiveDataActivity() {
    if (cache == String.Empty || source.Dirty()) {
      cache = source.SomeVeryExpensiveDataActivity();
      Console.WriteLine("Actually Fetching");
    } else {
      Console.WriteLine("Using Cache");
    }
      return cache;
  }

  public bool Dirty() { 
    return source.Dirty();
  }
}
