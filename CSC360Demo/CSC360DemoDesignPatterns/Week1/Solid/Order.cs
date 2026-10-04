namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed record Order(int Id, IReadOnlyList<OrderLine> Lines);

public sealed record OrderLine(string ProductName, int Quantity, decimal UnitPrice);
