using System.Reflection;

namespace CSC360DemoDesignPatterns.Proxy;

public class DispatchProxyAlternative : DispatchProxy
{
    private IDataSource? target;

    public static IDataSource Wrap(IDataSource target)
    {
        ArgumentNullException.ThrowIfNull(target);
        IDataSource proxy = Create<IDataSource, DispatchProxyAlternative>();
        ((DispatchProxyAlternative)proxy).target = target;
        return proxy;
    }

    protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
    {
        ArgumentNullException.ThrowIfNull(targetMethod);
        IDataSource dataSource = target ?? throw new InvalidOperationException("The proxy target has not been initialized.");
        return targetMethod.Invoke(dataSource, args);
    }
}
