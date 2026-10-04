namespace CSC360DemoDesignPatterns.Prototype;

public sealed record CharacterSnapshot(string Name, int Health)
{
    public CharacterSnapshot CloneWithHealth(int health) => this with { Health = health };
}
