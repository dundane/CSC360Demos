using CSC360DemoDesignPatterns.Iterator;

namespace CSC360Demo.InteractiveDemos;

public sealed class IteratorDemoSession : InteractiveDemoSessionBase
{
    private readonly List<string> items = ["alpha", "beta", "gamma"];
    public override string Name => "Iterator";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | add <value> | iterate | menu");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        switch (parts[0].ToLowerInvariant())
        {
            case "list":
                output.WriteLine($"Items: {string.Join(", ", items)}");
                break;
            case "add" when parts.Length > 1:
                items.Add(parts[1]);
                output.WriteLine($"Added '{parts[1]}'.");
                break;
            case "iterate":
                Trace(output, "Iterator/ConcreteCollection.cs :: CreateIterator", "Iterator/ConcreteIterator.cs :: MoveNext, Current");
                var iterator = new ConcreteCollection<string>(items.ToArray()).CreateIterator();
                while (iterator.MoveNext()) output.WriteLine(iterator.Current);
                output.WriteLine("C# alternative (foreach):");
                foreach (string item in items) output.WriteLine(item);
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }
}
