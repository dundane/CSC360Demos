using System.Reflection;
using CSC360DemoDesignPatterns.Bridge;

namespace CSC360Demo.InteractiveDemos;

public sealed class BridgeDemoSession : InteractiveDemoSessionBase
{
    private readonly Assembly assembly = typeof(IShape).Assembly;
    private Type? selectedShape;
    private Type? selectedColor;

    public override string Name => "Bridge";

    protected override void WriteHelp(TextWriter output)
    {
        output.WriteLine("shape <name> | color <name> | list | draw | menu");
    }

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        string action = parts[0].ToLowerInvariant();
        string argument = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        switch (action)
        {
            case "list":
                output.WriteLine($"Shapes: {string.Join(", ", ShapeTypes().Select(type => type.Name))}");
                output.WriteLine($"Colors: {string.Join(", ", ColorTypes().Select(type => DisplayName(type, "Color")))}");
                break;
            case "shape":
                selectedShape = FindType(ShapeTypes(), argument);
                output.WriteLine(selectedShape is null ? $"Unknown shape '{argument}'. Use list." : $"Shape set to {DisplayName(selectedShape)}.");
                break;
            case "color":
                selectedColor = FindType(ColorTypes(), argument, "Color");
                output.WriteLine(selectedColor is null ? $"Unknown color '{argument}'. Use list." : $"Color set to {DisplayName(selectedColor, "Color")}.");
                break;
            case "draw":
                Draw(output);
                break;
            default:
                output.WriteLine("Unknown command. Type help for available commands.");
                break;
        }
    }

    private IReadOnlyList<Type> ShapeTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<IShape>(
        assembly,
        type => type.GetConstructor([typeof(IColor)]) is not null);

    private IReadOnlyList<Type> ColorTypes() => InteractiveTypeDiscovery.FindConcreteImplementations<IColor>(
        assembly,
        type => type.GetConstructor(Type.EmptyTypes) is not null);

    private static Type? FindType(IEnumerable<Type> types, string name, string suffix = "") =>
        types.FirstOrDefault(type =>
            type.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
            || DisplayName(type, suffix).Equals(name, StringComparison.OrdinalIgnoreCase));

    private static string DisplayName(Type type, string suffix = "") =>
        suffix.Length > 0 && type.Name.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)
            ? type.Name[..^suffix.Length]
            : type.Name;

    private void Draw(TextWriter output)
    {
        if (selectedShape is null || selectedColor is null)
        {
            output.WriteLine("Choose a shape and color first. Use list to see available variations.");
            return;
        }

        string namespacePath = selectedShape.Namespace?.Replace("CSC360DemoDesignPatterns.", string.Empty, StringComparison.Ordinal)
            .Replace('.', '/') ?? "Bridge";
        Trace(output,
            $"Bridge/{selectedColor.Name}.cs :: .ctor, ApplyColor",
            $"{namespacePath}/{selectedShape.Name}.cs :: .ctor(IColor), Draw");

        var color = (IColor)Activator.CreateInstance(selectedColor)!;
        var shape = (IShape)Activator.CreateInstance(selectedShape, color)!;
        shape.Draw();
    }
}
