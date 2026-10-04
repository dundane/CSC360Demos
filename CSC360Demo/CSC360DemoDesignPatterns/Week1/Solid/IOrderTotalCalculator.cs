namespace CSC360DemoDesignPatterns.Week1.Solid;

public interface IOrderTotalCalculator
{
    decimal CalculateTotal(Order order, IDiscountPolicy discountPolicy);
}
