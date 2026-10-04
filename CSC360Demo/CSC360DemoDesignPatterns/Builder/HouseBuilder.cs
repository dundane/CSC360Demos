namespace CSC360DemoDesignPatterns.Builder;

public sealed record House(string Foundation, string Walls, string Roof, int Doors, int Windows);

public interface IHouseBuilder
{
    IHouseBuilder BuildFoundation(string foundation);
    IHouseBuilder BuildWalls(string walls);
    IHouseBuilder BuildRoof(string roof);
    IHouseBuilder AddDoors(int count);
    IHouseBuilder AddWindows(int count);
    House Build();
}

public sealed class ConcreteHouseBuilder : IHouseBuilder
{
    private string? foundation;
    private string? walls;
    private string? roof;
    private int doors;
    private int windows;

    public IHouseBuilder BuildFoundation(string value)
    {
        foundation = value;
        return this;
    }

    public IHouseBuilder BuildWalls(string value)
    {
        walls = value;
        return this;
    }

    public IHouseBuilder BuildRoof(string value)
    {
        roof = value;
        return this;
    }

    public IHouseBuilder AddDoors(int count)
    {
        doors = count;
        return this;
    }

    public IHouseBuilder AddWindows(int count)
    {
        windows = count;
        return this;
    }

    public House Build()
    {
        if (foundation is null || walls is null || roof is null)
        {
            throw new InvalidOperationException("A house requires a foundation, walls, and a roof.");
        }

        return new House(foundation, walls, roof, doors, windows);
    }
}
