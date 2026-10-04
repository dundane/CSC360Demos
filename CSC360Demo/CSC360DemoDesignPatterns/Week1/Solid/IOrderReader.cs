namespace CSC360DemoDesignPatterns.Week1.Solid;

public interface IOrderReader
{
    Order? FindById(int orderId);
}
