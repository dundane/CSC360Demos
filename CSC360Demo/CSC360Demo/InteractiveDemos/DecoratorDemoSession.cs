using CSC360DemoDesignPatterns.Decorator;

namespace CSC360Demo.InteractiveDemos;

public sealed class DecoratorDemoSession : InteractiveDemoSessionBase
{
    private readonly List<Type> decorators = [];
    private string text = "Sup Peeps!";
    public override string Name => "Decorator";

    protected override void WriteHelp(TextWriter output) => output.WriteLine("list | text <value> | add <decorator> | clear | render | menu");

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        string action = parts[0].ToLowerInvariant();
        string argument = parts.Length > 1 ? parts[1] : string.Empty;
        switch (action)
        {
            case "list":
                output.WriteLine($"Decorators: {string.Join(", ", DecoratorTypes().Select(type => type.Name))}");
                break;
            case "text" when argument.Length > 0:
                text = argument;
                output.WriteLine("Base text updated.");
                break;
            case "add":
                Type? decorator = DecoratorTypes().FirstOrDefault(type => type.Name.Equals(argument.Trim(), StringComparison.OrdinalIgnoreCase));
                if (decorator is null) output.WriteLine("Unknown decorator. Use list.");
                else { decorators.Add(decorator); output.WriteLine($"Added {decorator.Name}."); }
                break;
            case "clear":
                decorators.Clear();
                output.WriteLine("Decorator chain cleared.");
                break;
            case "render":
                IText rendered = new PlainTextValue(text);
                Trace(output, "Decorator/PlainText.cs :: Render");
                foreach (Type type in decorators)
                {
                    Trace(output, $"Decorator/{type.Name}.cs :: .ctor(IText), Render");
                    rendered = (IText)Activator.CreateInstance(type, rendered)!;
                }
                output.WriteLine(rendered.Render());
                break;
            default:
                output.WriteLine("Unknown or incomplete command. Type help.");
                break;
        }
    }

    private static IReadOnlyList<Type> DecoratorTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<IText>(
        typeof(IText).Assembly,
        type => type != typeof(PlainText) && type.GetConstructor([typeof(IText)]) is not null);

    private sealed class PlainTextValue(string value) : IText
    {
        public string Render() => value;
    }
}
