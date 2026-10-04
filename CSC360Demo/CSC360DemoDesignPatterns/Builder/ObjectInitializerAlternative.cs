namespace CSC360DemoDesignPatterns.Builder;

public sealed record SimpleHouseOptions
{
    public required string Foundation { get; init; }
    public required string Walls { get; init; }
    public required string Roof { get; init; }
}
