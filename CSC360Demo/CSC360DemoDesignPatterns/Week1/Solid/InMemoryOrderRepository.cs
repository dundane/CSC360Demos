namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class InMemoryOrderRepository : IOrderReader, IOrderWriter
{
    private readonly Dictionary<int, Order> orders = new();

    public Order? FindById(int orderId) => orders.GetValueOrDefault(orderId);

    public void Save(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
        orders[order.Id] = order;
    }
}
