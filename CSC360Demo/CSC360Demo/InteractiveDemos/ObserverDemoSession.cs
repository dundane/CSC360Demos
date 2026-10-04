using CSC360DemoDesignPatterns.Observer;

namespace CSC360Demo.InteractiveDemos;

public sealed class ObserverDemoSession : InteractiveDemoSessionBase
{
    private readonly ConcretePublisher publisher = new();
    private readonly Dictionary<string, ISubscriber> subscribers = new(StringComparer.OrdinalIgnoreCase);

    public override string Name => "Observer";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | add <observer> | remove <observer> | publish <state> | menu");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        string action = parts[0].ToLowerInvariant();
        string argument = parts.Length > 1 ? parts[1].Trim() : string.Empty;
        switch (action)
        {
            case "list":
                output.WriteLine($"Available: {string.Join(", ", ObserverTypes().Select(type => type.Name))}");
                output.WriteLine($"Registered: {string.Join(", ", subscribers.Keys)}");
                break;
            case "add":
                Type? type = ObserverTypes().FirstOrDefault(candidate => candidate.Name.Equals(argument, StringComparison.OrdinalIgnoreCase));
                if (type is null) output.WriteLine("Unknown observer. Use list.");
                else
                {
                    string key = type.Name;
                    if (subscribers.ContainsKey(key)) output.WriteLine($"{key} is already registered.");
                    else
                    {
                        var subscriber = (ISubscriber)Activator.CreateInstance(type)!;
                        subscribers.Add(key, subscriber);
                        publisher.RegisterSubscriber(subscriber);
                        output.WriteLine($"Registered {key}.");
                    }
                }
                break;
            case "remove":
                if (!subscribers.Remove(argument, out ISubscriber? removed)) output.WriteLine("That observer is not registered.");
                else { publisher.UnregisterSubscriber(removed); output.WriteLine($"Unregistered {argument}."); }
                break;
            case "publish":
                if (argument.Length == 0) output.WriteLine("Provide a state value: publish <state>.");
                else
                {
                    Trace(output, "Observer/ConcretePublisher.cs :: Publish", "Observer/ISubscriber.cs :: UpdateState");
                    publisher.Publish(argument);
                }
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }

    private static IReadOnlyList<Type> ObserverTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<ISubscriber>(
        typeof(ISubscriber).Assembly,
        type => type.GetConstructor(Type.EmptyTypes) is not null);
}
