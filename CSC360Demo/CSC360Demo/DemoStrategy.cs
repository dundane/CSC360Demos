namespace CSC360Demo;

internal interface IDemoStrategy
{
    string Name { get; }
    void Run();
}

internal sealed class DelegateDemoStrategy(string name, Action action) : IDemoStrategy
{
    public string Name { get; } = name;

    public void Run() => action();
}
