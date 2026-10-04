using CSC360DemoDesignPatterns.ChainOfResponsibility;

namespace CSC360Demo.InteractiveDemos;

public sealed class ChainOfResponsibilityDemoSession : InteractiveDemoSessionBase
{
    public override string Name => "Chain of Responsibility";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | request <category> <details> | menu");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
        switch (parts[0].ToLowerInvariant())
        {
            case "list":
                output.WriteLine($"Handlers: {string.Join(" -> ", HandlerTypes().Select(type => type.Name))}");
                break;
            case "request" when parts.Length == 3:
                SupportHandler? chain = null;
                foreach (Type type in HandlerTypes())
                {
                    var handler = (SupportHandler)Activator.CreateInstance(type)!;
                    if (chain is null) chain = handler;
                    else chain.SetNext(handler);
                }
                if (chain is null)
                {
                    output.WriteLine("No handlers were discovered.");
                    break;
                }
                Trace(output, "ChainOfResponsibility/SupportHandler.cs :: SetNext, Handle");
                output.WriteLine(chain.Handle(new SupportRequest(parts[1], parts[2])));
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }

    private static IReadOnlyList<Type> HandlerTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<SupportHandler>(
        typeof(SupportHandler).Assembly,
        type => type.GetConstructor(Type.EmptyTypes) is not null);
}
