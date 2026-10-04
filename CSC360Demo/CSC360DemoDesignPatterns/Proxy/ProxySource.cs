

namespace CSC360DemoDesignPatterns.Proxy;
public class ProxySource : IDataSource {
  private readonly IDataSource source;
  private string? cache;
  public ProxySource(IDataSource sourceToProxy) {
    source = sourceToProxy ?? throw new ArgumentNullException(nameof(sourceToProxy));
  }

  public string SomeVeryExpensiveDataActivity() {
    if (cache is null || source.Dirty()) {
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
