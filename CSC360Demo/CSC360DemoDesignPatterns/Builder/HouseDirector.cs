namespace CSC360DemoDesignPatterns.Builder;

public sealed class HouseDirector
{
    public House BuildFamilyHouse(IHouseBuilder builder)
    {
        return builder
            .BuildFoundation("Concrete")
            .BuildWalls("Brick")
            .BuildRoof("Tile")
            .AddDoors(2)
            .AddWindows(6)
            .Build();
    }
}
