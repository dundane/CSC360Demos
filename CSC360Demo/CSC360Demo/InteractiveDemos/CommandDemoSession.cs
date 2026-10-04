using CSC360DemoDesignPatterns.Command;

namespace CSC360Demo.InteractiveDemos;

public sealed class CommandDemoSession : InteractiveDemoSessionBase
{
    private readonly XboxControllerInvoker controller = new();
    private readonly CharacterReceiver receiver = new();

    public CommandDemoSession()
    {
        foreach (Type commandType in CommandTypes())
        {
            string name = CommandName(commandType);
            controller.SetCommand(name, (ICommandInterface)Activator.CreateInstance(commandType, receiver)!);
        }
    }

    public override string Name => "Command";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | press <command> | menu");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        switch (parts[0].ToLowerInvariant())
        {
            case "list":
                output.WriteLine($"Commands: {string.Join(", ", controller.commands.Keys)}");
                break;
            case "press" when parts.Length > 1:
                Trace(output, "Command/XboxControllerInvoker.cs :: PressButton", $"Command/{CommandTypeFor(parts[1].Trim())?.Name ?? "ICommandInterface"}.cs :: Execute");
                controller.PressButton(parts[1].Trim());
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }

    private static IReadOnlyList<Type> CommandTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<ICommandInterface>(
        typeof(ICommandInterface).Assembly,
        type => type.GetConstructor([typeof(ICharacter)]) is not null);

    private static string CommandName(Type type) => type.Name.EndsWith("Command", StringComparison.OrdinalIgnoreCase)
        ? type.Name[..^"Command".Length]
        : type.Name;

    private Type? CommandTypeFor(string name) => CommandTypes().FirstOrDefault(type =>
        CommandName(type).Equals(name, StringComparison.OrdinalIgnoreCase));
}
