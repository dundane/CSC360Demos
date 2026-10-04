namespace CSC360DemoDesignPatterns.FactoryMethod;

public static class FactoryDelegateAlternative
{
    public static T Create<T>(Func<T> factory)
    {
        ArgumentNullException.ThrowIfNull(factory);
        return factory();
    }
}
