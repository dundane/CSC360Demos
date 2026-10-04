using CSC360Demo.InteractiveDemos;
using CSC360DemoDesignPatterns.AbstractFactory;
using CSC360DemoDesignPatterns.Factory;

namespace CSC360DemoTests;

[TestClass]
public class InteractiveDemoTests
{
    [TestMethod]
    public void BridgeSessionAcceptsCommandsAndReturnsToMenu()
    {
        var session = new BridgeDemoSession();
        using var input = new StringReader("list\nshape Circle\ncolor Red\ndraw\nmenu\n");
        using var output = new StringWriter();

        session.Run(input, output);

        StringAssert.Contains(output.ToString(), "Shapes:");
        StringAssert.Contains(output.ToString(), "Color set to Red");
        StringAssert.Contains(output.ToString(), "Returning to the main menu.");
    }

    [TestMethod]
    public void StrategySessionCanChangeBehaviorBetweenCommands()
    {
        var session = new StrategyDemoSession();
        using var input = new StringReader("list\nuse BalancedStrategy\nattack\nmenu\n");
        using var output = new StringWriter();

        session.Run(input, output);

        StringAssert.Contains(output.ToString(), "Strategy set to BalancedStrategy");
        StringAssert.Contains(output.ToString(), "Strategy/BalancedStrategy.cs :: Attack");
    }

    [TestMethod]
    public void DecoratorSessionComposesDiscoveredDecorators()
    {
        var session = new DecoratorDemoSession();
        using var input = new StringReader("text hello\nadd BoldDecorator\nrender\nmenu\n");
        using var output = new StringWriter();

        session.Run(input, output);

        StringAssert.Contains(output.ToString(), "<b>hello</b>");
    }

    [TestMethod]
    public void StateSessionListsOnlySafeInteractiveSources()
    {
        var session = new StateDemoSession();
        using var input = new StringReader("list\nuse DemoMusicSource\nplay\ntoggle\nmenu\n");
        using var output = new StringWriter();

        session.Run(input, output);

        StringAssert.Contains(output.ToString(), "DemoMusicSource");
        StringAssert.Contains(output.ToString(), "Demo track");
        Assert.IsFalse(output.ToString().Contains("AMRadio", StringComparison.Ordinal));
    }

    [TestMethod]
    public void AnimalFactoriesExposeDiscoveredFamilyAndProducts()
    {
        var provider = new AnimalFactoryAbstract();
        CollectionAssert.Contains(provider.FactoryTypes.ToArray(), "Pet");
        CollectionAssert.Contains(provider.FactoryTypes.ToArray(), "Wild");
        CollectionAssert.Contains(provider.GetFactory("pet").AnimalTypes.ToArray(), "Dog");
        Assert.IsInstanceOfType(provider.GetFactory("wild").CreateAnimal("dog"), typeof(IAnimal));
    }
}
