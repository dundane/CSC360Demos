namespace CSC360DemoDesignPatterns.Week1.Solid;

public interface IReceiptFormatter
{
    string Format(Order order, decimal total);
}
