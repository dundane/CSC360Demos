using CSC360DemoDesignPatterns.Strategy;

namespace CSC360Demo.InteractiveDemos;

public sealed class StrategyDemoSession : InteractiveDemoSessionBase
{
    private IAIOpponent? opponent;
    public override string Name => "Strategy";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | use <strategy> | attack | menu");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        switch (parts[0].ToLowerInvariant())
        {
            case "list":
                output.WriteLine($"Strategies: {string.Join(", ", StrategyTypes().Select(type => type.Name))}");
                break;
            case "use" when parts.Length > 1:
                Type? type = StrategyTypes().FirstOrDefault(candidate => candidate.Name.Equals(parts[1].Trim(), StringComparison.OrdinalIgnoreCase));
                if (type is null)
                {
                    output.WriteLine("Unknown strategy. Use list to see available strategies.");
                    break;
                }
                var strategy = (IAIStrategy)Activator.CreateInstance(type)!;
                opponent ??= new AIOpponent(strategy);
                opponent.SetStrategy(strategy);
                selectedStrategyName = type.Name;
                output.WriteLine($"Strategy set to {type.Name}.");
                break;
            case "attack":
                if (opponent is null)
                {
                    output.WriteLine("Choose a strategy first with use <strategy>.");
                    break;
                }
                Type strategyType = StrategyTypes().First(type => type.Name.Equals(selectedStrategyName, StringComparison.OrdinalIgnoreCase));
                Trace(output, "Strategy/AIOpponent.cs :: Attack", $"Strategy/{strategyType.Name}.cs :: Attack");
                opponent.Attack();
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }

    private static IReadOnlyList<Type> StrategyTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<IAIStrategy>(
        typeof(IAIStrategy).Assembly,
        type => type.GetConstructor(Type.EmptyTypes) is not null);

    private string? selectedStrategyName;
}
