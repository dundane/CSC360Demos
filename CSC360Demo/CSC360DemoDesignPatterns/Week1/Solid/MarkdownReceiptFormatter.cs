using System.Globalization;

namespace CSC360DemoDesignPatterns.Week1.Solid;

public sealed class MarkdownReceiptFormatter : IReceiptFormatter
{
    public string Format(Order order, decimal total)
    {
        ArgumentNullException.ThrowIfNull(order);
        return $"**Order {order.Id}** — {total.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}
