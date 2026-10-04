namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class OrderSummaryService
{
    private readonly IOrderReader orderReader;
    private readonly IOrderTotalCalculator totalCalculator;
    private readonly IDiscountPolicy discountPolicy;
    private readonly IReceiptFormatter receiptFormatter;

    public OrderSummaryService(
        IOrderReader orderReader,
        IOrderTotalCalculator totalCalculator,
        IDiscountPolicy discountPolicy,
        IReceiptFormatter receiptFormatter)
    {
        this.orderReader = orderReader ?? throw new ArgumentNullException(nameof(orderReader));
        this.totalCalculator = totalCalculator ?? throw new ArgumentNullException(nameof(totalCalculator));
        this.discountPolicy = discountPolicy ?? throw new ArgumentNullException(nameof(discountPolicy));
        this.receiptFormatter = receiptFormatter ?? throw new ArgumentNullException(nameof(receiptFormatter));
    }

    public string GetReceipt(int orderId)
    {
        Order order = orderReader.FindById(orderId)
            ?? throw new KeyNotFoundException($"Order {orderId} was not found.");
        return receiptFormatter.Format(order, totalCalculator.CalculateTotal(order, discountPolicy));
    }
}
