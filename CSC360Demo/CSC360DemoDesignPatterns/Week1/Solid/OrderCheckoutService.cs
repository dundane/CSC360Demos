namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class OrderCheckoutService
{
    private readonly IOrderWriter orderWriter;
    private readonly IOrderTotalCalculator totalCalculator;
    private readonly IDiscountPolicy discountPolicy;
    private readonly IReceiptFormatter receiptFormatter;

    public OrderCheckoutService(
        IOrderWriter orderWriter,
        IOrderTotalCalculator totalCalculator,
        IDiscountPolicy discountPolicy,
        IReceiptFormatter receiptFormatter)
    {
        this.orderWriter = orderWriter ?? throw new ArgumentNullException(nameof(orderWriter));
        this.totalCalculator = totalCalculator ?? throw new ArgumentNullException(nameof(totalCalculator));
        this.discountPolicy = discountPolicy ?? throw new ArgumentNullException(nameof(discountPolicy));
        this.receiptFormatter = receiptFormatter ?? throw new ArgumentNullException(nameof(receiptFormatter));
    }

    public string Checkout(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
        decimal total = totalCalculator.CalculateTotal(order, discountPolicy);
        orderWriter.Save(order);
        return receiptFormatter.Format(order, total);
    }
}
