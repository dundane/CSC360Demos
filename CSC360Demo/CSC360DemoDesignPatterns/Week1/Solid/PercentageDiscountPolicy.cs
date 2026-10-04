namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class PercentageDiscountPolicy(decimal rate) : IDiscountPolicy
{
    private readonly decimal rate = rate is >= 0 and <= 1
        ? rate
        : throw new ArgumentOutOfRangeException(nameof(rate), "Rate must be between zero and one.");

    public decimal CalculateDiscount(decimal subtotal) => subtotal * rate;
}
