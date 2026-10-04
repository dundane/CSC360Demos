using CSC360DemoDesignPatterns.Factory;

namespace CSC360DemoDesignPatterns.FactoryMethod;

public abstract class AnimalShelter
{
    public string AdoptAnimal() => CreateAnimal().Speak();

    protected abstract IAnimal CreateAnimal();
}

public sealed class DogShelter : AnimalShelter
{
    protected override IAnimal CreateAnimal() => new Dog();
}

public sealed class CatShelter : AnimalShelter
{
    protected override IAnimal CreateAnimal() => new Cat();
}
