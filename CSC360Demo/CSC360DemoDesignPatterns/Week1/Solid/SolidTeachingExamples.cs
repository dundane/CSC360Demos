namespace CSC360DemoDesignPatterns.Week1.Solid;

public static class SolidTeachingExamples
{
    public static void RunAll()
    {
        RunSingleResponsibility();
        RunOpenClosed();
        RunLiskovSubstitution();
        RunInterfaceSegregation();
        RunDependencyInversion();
        RunIntegratedWorkflow();
    }

    public static void RunSingleResponsibility()
    {
        TraceCalls("Week1/Solid/SolidTeachingExamples.cs :: CreateSampleOrder");
        Order order = CreateSampleOrder();
        var subtotalCalculator = new OrderSubtotalCalculator();
        var receiptFormatter = new PlainTextReceiptFormatter();

        Console.WriteLine("SRP — calculation and presentation have separate responsibilities");
        TraceCalls("Week1/Solid/OrderSubtotalCalculator.cs :: CalculateSubtotal");
        decimal subtotal = subtotalCalculator.CalculateSubtotal(order);
        Console.WriteLine($"Subtotal: {subtotal:C}");
        TraceCalls("Week1/Solid/PlainTextReceiptFormatter.cs :: Format");
        Console.WriteLine(receiptFormatter.Format(order, subtotal));
    }

    public static void RunOpenClosed()
    {
        TraceCalls("Week1/Solid/SolidTeachingExamples.cs :: CreateSampleOrder");
        Order order = CreateSampleOrder();
        IOrderTotalCalculator calculator = CreateTotalCalculator();

        Console.WriteLine("OCP — add a discount policy without changing the total calculator");
        TraceCalls("Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/OrderSubtotalCalculator.cs :: CalculateSubtotal", "Week1/Solid/NoDiscountPolicy.cs :: CalculateDiscount");
        Console.WriteLine($"No discount: {calculator.CalculateTotal(order, new NoDiscountPolicy()):C}");
        TraceCalls("Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/OrderSubtotalCalculator.cs :: CalculateSubtotal", "Week1/Solid/PercentageDiscountPolicy.cs :: CalculateDiscount");
        Console.WriteLine($"10% discount: {calculator.CalculateTotal(order, new PercentageDiscountPolicy(0.10m)):C}");
    }

    public static void RunLiskovSubstitution()
    {
        TraceCalls("Week1/Solid/SolidTeachingExamples.cs :: CreateSampleOrder");
        Order order = CreateSampleOrder();

        Console.WriteLine("LSP — both policies honor the discount contract and can be substituted");
        PrintTotal(order, new NoDiscountPolicy());
        PrintTotal(order, new PercentageDiscountPolicy(0.10m));
    }

    public static void RunInterfaceSegregation()
    {
        TraceCalls("Week1/Solid/SolidTeachingExamples.cs :: CreateSampleOrder");
        Order order = CreateSampleOrder();
        var repository = new InMemoryOrderRepository();
        IOrderWriter writer = repository;
        TraceCalls("Week1/Solid/InMemoryOrderRepository.cs :: Save");
        writer.Save(order);

        IOrderReader reader = repository;
        var summary = new OrderSummaryService(reader, CreateTotalCalculator(), new NoDiscountPolicy(), new PlainTextReceiptFormatter());

        Console.WriteLine("ISP — checkout needs a writer; receipt lookup needs only a reader");
        TraceCalls("Week1/Solid/OrderSummaryService.cs :: GetReceipt", "Week1/Solid/InMemoryOrderRepository.cs :: FindById", "Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/PlainTextReceiptFormatter.cs :: Format");
        Console.WriteLine(summary.GetReceipt(order.Id));
    }

    public static void RunDependencyInversion()
    {
        TraceCalls("Week1/Solid/SolidTeachingExamples.cs :: CreateSampleOrder");
        Order order = CreateSampleOrder();
        IOrderWriter repository = new InMemoryOrderRepository();
        IOrderTotalCalculator calculator = CreateTotalCalculator();
        IDiscountPolicy discountPolicy = new PercentageDiscountPolicy(0.10m);
        IReceiptFormatter formatter = new PlainTextReceiptFormatter();
        var checkout = new OrderCheckoutService(repository, calculator, discountPolicy, formatter);

        Console.WriteLine("DIP — checkout receives abstractions rather than concrete infrastructure");
        TraceCalls("Week1/Solid/OrderCheckoutService.cs :: Checkout", "Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/OrderSubtotalCalculator.cs :: CalculateSubtotal", "Week1/Solid/PercentageDiscountPolicy.cs :: CalculateDiscount", "Week1/Solid/InMemoryOrderRepository.cs :: Save", "Week1/Solid/PlainTextReceiptFormatter.cs :: Format");
        Console.WriteLine(checkout.Checkout(order));
    }

    public static void RunIntegratedWorkflow()
    {
        TraceCalls("Week1/Solid/SolidTeachingExamples.cs :: CreateSampleOrder");
        Order order = CreateSampleOrder();
        var repository = new InMemoryOrderRepository();
        IOrderWriter writer = repository;
        IOrderReader reader = repository;
        IOrderTotalCalculator calculator = CreateTotalCalculator();
        IDiscountPolicy discountPolicy = new PercentageDiscountPolicy(0.10m);
        IReceiptFormatter formatter = new PlainTextReceiptFormatter();
        var checkout = new OrderCheckoutService(writer, calculator, discountPolicy, formatter);
        var summary = new OrderSummaryService(reader, calculator, discountPolicy, formatter);

        Console.WriteLine("All five principles together — save an order, apply a policy, format, then retrieve it");
        TraceCalls("Week1/Solid/OrderCheckoutService.cs :: Checkout", "Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/OrderSubtotalCalculator.cs :: CalculateSubtotal", "Week1/Solid/PercentageDiscountPolicy.cs :: CalculateDiscount", "Week1/Solid/InMemoryOrderRepository.cs :: Save", "Week1/Solid/PlainTextReceiptFormatter.cs :: Format");
        Console.WriteLine(checkout.Checkout(order));
        TraceCalls("Week1/Solid/OrderSummaryService.cs :: GetReceipt", "Week1/Solid/InMemoryOrderRepository.cs :: FindById", "Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/PercentageDiscountPolicy.cs :: CalculateDiscount", "Week1/Solid/PlainTextReceiptFormatter.cs :: Format");
        Console.WriteLine($"Retrieved: {summary.GetReceipt(order.Id)}");
    }

    public static Order CreateSampleOrder() => new(
        42,
        [
            new OrderLine("Coffee", 2, 3.50m),
            new OrderLine("Notebook", 1, 5.00m)
        ]);

    private static IOrderTotalCalculator CreateTotalCalculator() => new OrderTotalCalculator(new OrderSubtotalCalculator());

    private static void PrintTotal(Order order, IDiscountPolicy policy)
    {
        TraceCalls("Week1/Solid/OrderTotalCalculator.cs :: CalculateTotal", "Week1/Solid/OrderSubtotalCalculator.cs :: CalculateSubtotal", $"Week1/Solid/{policy.GetType().Name}.cs :: CalculateDiscount");
        Console.WriteLine($"{policy.GetType().Name}: {CreateTotalCalculator().CalculateTotal(order, policy):C}");
    }

    private static void TraceCalls(params string[] calls)
    {
        foreach (string call in calls)
        {
            Console.WriteLine($"  -> {call}");
        }
    }
}
