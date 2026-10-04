using CSC360DemoDesignPatterns.AbstractFactory;
using CSC360DemoDesignPatterns.Factory;

namespace CSC360Demo.InteractiveDemos;

public sealed class AnimalFactoryDemoSession : InteractiveDemoSessionBase
{
    private readonly AnimalFactoryAbstract factoryProvider = new();
    private IAnimalFactory currentFactory;
    private IAnimal? currentAnimal;

    public AnimalFactoryDemoSession()
    {
        string firstFactory = factoryProvider.FactoryTypes.FirstOrDefault()
            ?? throw new InvalidOperationException("No animal factories were discovered.");
        currentFactory = factoryProvider.GetFactory(firstFactory);
    }

    public override string Name => "Abstract Factory";

    protected override void WriteHelp(TextWriter output)
    {
        output.WriteLine("families | family <name> | list | animal <name> | speak | menu");
    }

    protected override void ExecuteCommand(string command, TextWriter output)
    {
        string[] parts = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
        string action = parts[0].ToLowerInvariant();
        string argument = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        switch (action)
        {
            case "families":
                Trace(output, "AbstractFactory/AnimalFactoryAbstract.cs :: get_FactoryTypes");
                output.WriteLine($"Families: {string.Join(", ", factoryProvider.FactoryTypes)}");
                break;
            case "family":
                SelectFactory(argument, output);
                break;
            case "list":
                Trace(output, "AbstractFactory/IAnimalFactory.cs :: get_AnimalTypes");
                output.WriteLine($"{currentFactory.GetType().Name} animals: {string.Join(", ", currentFactory.AnimalTypes)}");
                break;
            case "animal":
                SelectAnimal(argument, output);
                break;
            case "speak":
                Speak(output);
                break;
            default:
                output.WriteLine("Unknown command. Type help for available commands.");
                break;
        }
    }

    private void SelectFactory(string family, TextWriter output)
    {
        if (string.IsNullOrWhiteSpace(family))
        {
            output.WriteLine("Choose a family. Use families to list available factories.");
            return;
        }

        Trace(output, "AbstractFactory/AnimalFactoryAbstract.cs :: GetFactory");
        try
        {
            currentFactory = factoryProvider.GetFactory(family);
            currentAnimal = null;
            output.WriteLine($"Factory set to {currentFactory.GetType().Name}. Use list to see its animals.");
        }
        catch (ArgumentException exception)
        {
            output.WriteLine(exception.Message);
        }
    }

    private void SelectAnimal(string animalName, TextWriter output)
    {
        if (string.IsNullOrWhiteSpace(animalName))
        {
            output.WriteLine("Choose an animal. Use list to see available types.");
            return;
        }

        string factoryFile = currentFactory is PetAnimalFactory ? "Factory/AnimalFactory.cs" : $"AbstractFactory/{currentFactory.GetType().Name}.cs";
        Trace(output, $"{factoryFile} :: CreateAnimal");
        try
        {
            currentAnimal = currentFactory.CreateAnimal(animalName);
            output.WriteLine($"Animal set to {currentAnimal.GetType().Name}.");
        }
        catch (ArgumentException exception)
        {
            output.WriteLine(exception.Message);
        }
    }

    private void Speak(TextWriter output)
    {
        if (currentAnimal is null)
        {
            output.WriteLine("Choose an animal first with animal <name>.");
            return;
        }

        Trace(output, $"{AnimalNamespacePath(currentAnimal)}/{currentAnimal.GetType().Name}.cs :: Speak");
        output.WriteLine(currentAnimal.Speak());
    }

    private static string AnimalNamespacePath(IAnimal animal) =>
        animal.GetType().Namespace?.Replace("CSC360DemoDesignPatterns.", string.Empty, StringComparison.Ordinal).Replace('.', '/')
        ?? "Factory";
}
