using CSC360DemoDesignPatterns.State;

namespace CSC360Demo.InteractiveDemos;

public sealed class StateDemoSession : InteractiveDemoSessionBase
{
    private readonly Context context = new();
    private readonly SwitchStateAlternative switchAlternative = new();
    private IInteractiveBoomBoxSource? selectedSource;

    public override string Name => "State";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | use <source> | play | toggle | menu (available sources return text only; no external media is launched)");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        switch (parts[0].ToLowerInvariant())
        {
            case "list":
                output.WriteLine($"Sources: {string.Join(", ", SourceTypes().Select(type => type.Name))}; PlaybackStateAlternative: Stopped/Playing");
                break;
            case "use" when parts.Length > 1:
                Type? type = SourceTypes().FirstOrDefault(candidate => candidate.Name.Equals(parts[1].Trim(), StringComparison.OrdinalIgnoreCase));
                if (type is null)
                {
                    output.WriteLine("Unknown source. Use list to see available sources.");
                    break;
                }
                selectedSource = (IInteractiveBoomBoxSource)Activator.CreateInstance(type)!;
                context.SetContext(selectedSource);
                output.WriteLine($"Source set to {type.Name}.");
                break;
            case "play":
                if (selectedSource is null)
                {
                    output.WriteLine("Choose a source first with use <source>.");
                    break;
                }
                Trace(output, "State/Context.cs :: PlayMusic", $"State/{selectedSource.GetType().Name}.cs :: PlayMuisc, Source");
                output.WriteLine(context.PlayMusic());
                break;
            case "toggle":
                Trace(output, "State/SwitchStateAlternative.cs :: Toggle");
                output.WriteLine($"Playback state: {switchAlternative.Toggle()}");
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }

    private static IReadOnlyList<Type> SourceTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<IInteractiveBoomBoxSource>(
        typeof(IInteractiveBoomBoxSource).Assembly,
        type => type.GetConstructor(Type.EmptyTypes) is not null);
}
