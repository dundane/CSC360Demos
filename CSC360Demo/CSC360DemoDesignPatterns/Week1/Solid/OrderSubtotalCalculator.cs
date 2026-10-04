namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class OrderSubtotalCalculator : IOrderSubtotalCalculator
{
    public decimal CalculateSubtotal(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
        ArgumentNullException.ThrowIfNull(order.Lines);

        return order.Lines.Sum(line => line.Quantity * line.UnitPrice);
    }
}
