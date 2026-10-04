namespace CSC360DemoDesignPatterns.Prototype;

public sealed class GameCharacter : ICloneable
{
    public GameCharacter(string name, int health, List<string> equipment)
    {
        Name = name;
        Health = health;
        Equipment = equipment;
    }

    public string Name { get; set; }
    public int Health { get; set; }
    public List<string> Equipment { get; }

    public GameCharacter Clone() => new(Name, Health, [.. Equipment]);

    object ICloneable.Clone() => Clone();
}
