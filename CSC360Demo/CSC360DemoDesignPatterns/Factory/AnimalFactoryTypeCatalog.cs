using System.Reflection;

namespace CSC360DemoDesignPatterns.Factory;

internal sealed class AnimalFactoryTypeCatalog
{
    private readonly IReadOnlyDictionary<string, Type> animals;

    public AnimalFactoryTypeCatalog(Type factoryType, string classNamePrefix = "")
    {
        ArgumentNullException.ThrowIfNull(factoryType);
        string familyNamespace = factoryType.Namespace
            ?? throw new ArgumentException("The factory must belong to a namespace.", nameof(factoryType));

        animals = typeof(IAnimal).Assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.Namespace == familyNamespace)
            .Where(type => typeof(IAnimal).IsAssignableFrom(type) && type.GetConstructor(Type.EmptyTypes) is not null)
            .Select(type => new { Name = GetAnimalName(type.Name, classNamePrefix), Type = type })
            .Where(item => item.Name.Length > 0)
            .ToDictionary(item => item.Name, item => item.Type, StringComparer.OrdinalIgnoreCase);
    }

    public IReadOnlyList<string> Names => animals.Keys.Order(StringComparer.OrdinalIgnoreCase).ToArray();

    public IAnimal Create(string animalName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(animalName);
        if (!animals.TryGetValue(animalName.Trim(), out Type? animalType))
        {
            throw new ArgumentException($"Unknown animal type '{animalName}'. Available types: {string.Join(", ", Names)}.", nameof(animalName));
        }

        return (IAnimal)(Activator.CreateInstance(animalType)
            ?? throw new InvalidOperationException($"Could not create {animalType.Name}."));
    }

    private static string GetAnimalName(string className, string prefix)
    {
        string name = className;
        if (prefix.Length > 0 && name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            name = name[prefix.Length..];
        }

        return name;
    }
}
