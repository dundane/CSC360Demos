namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class NoDiscountPolicy : IDiscountPolicy
{
    public decimal CalculateDiscount(decimal subtotal) => 0;
}
