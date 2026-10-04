namespace CSC360DemoDesignPatterns.Singleton;

public static class StaticClassAlternative
{
    public static string ServiceId { get; } = Guid.NewGuid().ToString();
}
