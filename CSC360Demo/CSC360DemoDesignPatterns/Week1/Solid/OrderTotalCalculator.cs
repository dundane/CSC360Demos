namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class OrderTotalCalculator(IOrderSubtotalCalculator subtotalCalculator) : IOrderTotalCalculator
{
    private readonly IOrderSubtotalCalculator subtotalCalculator = subtotalCalculator ?? throw new ArgumentNullException(nameof(subtotalCalculator));

    public decimal CalculateTotal(Order order, IDiscountPolicy discountPolicy)
    {
        ArgumentNullException.ThrowIfNull(order);
        ArgumentNullException.ThrowIfNull(discountPolicy);

        decimal subtotal = subtotalCalculator.CalculateSubtotal(order);
        decimal discount = discountPolicy.CalculateDiscount(subtotal);
        if (discount < 0 || discount > subtotal)
        {
            throw new InvalidOperationException("A discount must be between zero and the order subtotal.");
        }

        return subtotal - discount;
    }
}
