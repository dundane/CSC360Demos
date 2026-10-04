namespace CSC360Demo.InteractiveDemos;

internal sealed class InteractiveDemoStrategy(IInteractiveDemoSession session) : IDemoStrategy
{
    public string Name => session.Name;

    public void Run() => session.Run(Console.In, Console.Out);
}
