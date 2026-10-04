using CSC360DemoDesignPatterns.Week1.Solid;
using CSC360DemoDesignPatterns.Command.UndoRedoDemo;

namespace CSC360DemoTests;

[TestClass]
public class SolidExamplesTests
{
    [TestMethod]
    public void SubtotalCalculatorCalculatesOnlyLineTotals()
    {
        Order order = SolidTeachingExamples.CreateSampleOrder();

        Assert.AreEqual(12m, new OrderSubtotalCalculator().CalculateSubtotal(order));
    }

    [TestMethod]
    public void TotalCalculatorIsOpenToDifferentDiscountPolicies()
    {
        Order order = SolidTeachingExamples.CreateSampleOrder();
        IOrderTotalCalculator calculator = new OrderTotalCalculator(new OrderSubtotalCalculator());

        Assert.AreEqual(12m, calculator.CalculateTotal(order, new NoDiscountPolicy()));
        Assert.AreEqual(10.8m, calculator.CalculateTotal(order, new PercentageDiscountPolicy(0.10m)));
    }

    [TestMethod]
    public void DiscountPoliciesAreSubstitutableWithinTheirContract()
    {
        IDiscountPolicy[] policies = [new NoDiscountPolicy(), new PercentageDiscountPolicy(0.25m)];
        IOrderTotalCalculator calculator = new OrderTotalCalculator(new OrderSubtotalCalculator());
        Order order = SolidTeachingExamples.CreateSampleOrder();
        decimal subtotal = new OrderSubtotalCalculator().CalculateSubtotal(order);

        foreach (IDiscountPolicy policy in policies)
        {
            decimal discount = policy.CalculateDiscount(subtotal);
            decimal total = calculator.CalculateTotal(order, policy);

            Assert.IsTrue(discount >= 0 && discount <= subtotal);
            Assert.IsTrue(total >= 0 && total <= subtotal);
        }
    }

    [TestMethod]
    public void TotalCalculatorRejectsPolicyThatBreaksDiscountContract()
    {
        var calculator = new OrderTotalCalculator(new OrderSubtotalCalculator());

        Assert.ThrowsException<InvalidOperationException>(() =>
            calculator.CalculateTotal(SolidTeachingExamples.CreateSampleOrder(), new InvalidDiscountPolicy()));
    }

    [TestMethod]
    public void ReceiptServiceNeedsOnlyReaderInterface()
    {
        Order order = SolidTeachingExamples.CreateSampleOrder();
        IOrderReader reader = new ReaderOnly(order);
        var service = new OrderSummaryService(
            reader,
            new OrderTotalCalculator(new OrderSubtotalCalculator()),
            new NoDiscountPolicy(),
            new PlainTextReceiptFormatter());

        Assert.AreEqual("Order 42: $12.00", service.GetReceipt(order.Id));
    }

    [TestMethod]
    public void CheckoutNeedsOnlyWriterInterface()
    {
        var writer = new WriterOnly();
        var service = new OrderCheckoutService(
            writer,
            new OrderTotalCalculator(new OrderSubtotalCalculator()),
            new NoDiscountPolicy(),
            new PlainTextReceiptFormatter());
        Order order = SolidTeachingExamples.CreateSampleOrder();

        string receipt = service.Checkout(order);

        Assert.AreSame(order, writer.SavedOrder);
        Assert.AreEqual("Order 42: $12.00", receipt);
    }

    [TestMethod]
    public void IntegratedWorkflowPersistsAndRetrievesDiscountedOrder()
    {
        var repository = new InMemoryOrderRepository();
        IOrderWriter writer = repository;
        IOrderReader reader = repository;
        IOrderTotalCalculator calculator = new OrderTotalCalculator(new OrderSubtotalCalculator());
        IDiscountPolicy discount = new PercentageDiscountPolicy(0.10m);
        IReceiptFormatter formatter = new PlainTextReceiptFormatter();
        var checkout = new OrderCheckoutService(writer, calculator, discount, formatter);
        var summary = new OrderSummaryService(reader, calculator, discount, formatter);
        Order order = SolidTeachingExamples.CreateSampleOrder();

        Assert.AreEqual("Order 42: $10.80", checkout.Checkout(order));
        Assert.AreEqual("Order 42: $10.80", summary.GetReceipt(order.Id));
    }

    [TestMethod]
    [DoNotParallelize]
    public void WalkthroughsPrintFileAndMethodCallFlowsInOrder()
    {
        TextWriter originalOutput = Console.Out;
        using var capturedOutput = new StringWriter();
        try
        {
            Console.SetOut(capturedOutput);
            SolidTeachingExamples.RunSingleResponsibility();
            UndoRedoWalkthrough.Run();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }

        string output = capturedOutput.ToString();
        int subtotalCall = output.IndexOf("OrderSubtotalCalculator.cs :: CalculateSubtotal", StringComparison.Ordinal);
        int formatterCall = output.IndexOf("PlainTextReceiptFormatter.cs :: Format", StringComparison.Ordinal);
        int undoCall = output.IndexOf("UndoRedoHistory.cs :: Undo", StringComparison.Ordinal);
        int undoResult = output.IndexOf("After undo:", StringComparison.Ordinal);

        Assert.IsTrue(subtotalCall >= 0 && formatterCall > subtotalCall);
        Assert.IsTrue(undoCall >= 0 && undoResult > undoCall);
    }

    private sealed class ReaderOnly(Order order) : IOrderReader
    {
        public Order? FindById(int orderId) => order.Id == orderId ? order : null;
    }

    private sealed class WriterOnly : IOrderWriter
    {
        public Order? SavedOrder { get; private set; }
        public void Save(Order order) => SavedOrder = order;
    }

    private sealed class InvalidDiscountPolicy : IDiscountPolicy
    {
        public decimal CalculateDiscount(decimal subtotal) => subtotal + 1;
    }
}
