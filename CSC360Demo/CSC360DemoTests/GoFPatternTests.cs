using CSC360DemoDesignPatterns.AbstractFactory;
using CSC360DemoDesignPatterns.Adapter;
using CSC360DemoDesignPatterns.Builder;
using CSC360DemoDesignPatterns.ChainOfResponsibility;
using CSC360DemoDesignPatterns.Command;
using CSC360DemoDesignPatterns.Command.UndoRedoDemo;
using CSC360DemoDesignPatterns.Factory;
using CSC360DemoDesignPatterns.FactoryMethod;
using CSC360DemoDesignPatterns.Interpreter;
using CSC360DemoDesignPatterns.Iterator;
using CSC360DemoDesignPatterns.Mediator;
using CSC360DemoDesignPatterns.Memento;
using CSC360DemoDesignPatterns.Observer;
using CSC360DemoDesignPatterns.Prototype;
using CSC360DemoDesignPatterns.Proxy;
using CSC360DemoDesignPatterns.Singleton;
using CSC360DemoDesignPatterns.TemplateMethod;
using CSC360DemoDesignPatterns.State;
using CSC360DemoDesignPatterns.Strategy;
using CSC360DemoDesignPatterns.Visitor;

namespace CSC360DemoTests;

[TestClass]
public class GoFPatternTests
{
    [TestMethod]
    public void BuilderDirectorCreatesCompleteHouse()
    {
        House house = new HouseDirector().BuildFamilyHouse(new ConcreteHouseBuilder());

        Assert.AreEqual("Concrete", house.Foundation);
        Assert.AreEqual(2, house.Doors);
        Assert.AreEqual(6, house.Windows);
    }

    [TestMethod]
    public void BuilderRejectsIncompleteProduct()
    {
        Assert.ThrowsException<InvalidOperationException>(() => new ConcreteHouseBuilder().Build());
    }

    [TestMethod]
    public void ChainOfResponsibilityRoutesToMatchingHandler()
    {
        var billing = new BillingSupportHandler();
        billing.SetNext(new TechnicalSupportHandler());

        Assert.AreEqual("Technical support resolved: Sign in", billing.Handle(new SupportRequest("technical", "Sign in")));
    }

    [TestMethod]
    public void InterpreterEvaluatesExpressionAndReportsMissingVariables()
    {
        IExpression expression = new SubtractExpression(new AddExpression(new VariableExpression("x"), new NumberExpression(4)), new NumberExpression(2));

        Assert.AreEqual(7, expression.Interpret(new Dictionary<string, int> { ["x"] = 5 }));
        Assert.ThrowsException<KeyNotFoundException>(() => new VariableExpression("missing").Interpret(new Dictionary<string, int>()));
    }

    [TestMethod]
    public void MementoRestoresPreviousEditorState()
    {
        var editor = new TextEditor();
        var history = new EditorHistory();
        editor.Write("saved");
        history.Save(editor);
        editor.Write(" changes");

        Assert.IsTrue(history.Undo(editor));
        Assert.AreEqual("saved", editor.Text);
        Assert.IsFalse(history.Undo(editor));
    }

    [TestMethod]
    public void PrototypeCopiesMutableEquipmentIndependently()
    {
        var original = new GameCharacter("Ranger", 100, ["Bow"]);
        GameCharacter clone = original.Clone();
        clone.Equipment.Add("Cloak");

        Assert.AreEqual(1, original.Equipment.Count);
        Assert.AreEqual(2, clone.Equipment.Count);
    }

    [TestMethod]
    public void RecordWithExpressionCopiesPrototypeWithoutChangingOriginal()
    {
        var original = new CharacterSnapshot("Ranger", 100);
        CharacterSnapshot clone = original.CloneWithHealth(75);

        Assert.AreEqual(100, original.Health);
        Assert.AreEqual(75, clone.Health);
        Assert.AreEqual(original.Name, clone.Name);
    }

    [TestMethod]
    public void TemplateMethodRunsConcreteMiningSteps()
    {
        Assert.AreEqual("CSV records: 2", new CsvDataMiner().Mine("name,score\nAda,100\n"));
    }

    [TestMethod]
    public void VisitorCalculatesAreasAcrossDifferentShapes()
    {
        var visitor = new AreaVisitor();
        new Circle(2).Accept(visitor);
        new Rectangle(3, 4).Accept(visitor);

        Assert.AreEqual(Math.PI * 4 + 12, visitor.TotalArea, 0.0001);
    }

    [TestMethod]
    public void FactoryMethodDelegatesCreationToConcreteShelter()
    {
        Assert.AreEqual("Bark Bark", new DogShelter().AdoptAnimal());
        Assert.AreEqual("Meow!", new CatShelter().AdoptAnimal());
    }

    [TestMethod]
    public void SingletonOneReturnsSameInstanceAcrossThreads()
    {
        SingletonOne[] instances = Enumerable.Range(0, 32)
            .AsParallel()
            .Select(_ => SingletonOne.GetInstance())
            .ToArray();

        Assert.IsTrue(instances.All(instance => ReferenceEquals(instances[0], instance)));
    }

    [TestMethod]
    public void ProxyCachesCleanDataAndRefreshesDirtyData()
    {
        var source = new CountingDataSource();
        var proxy = new ProxySource(source);

        Assert.AreEqual("data-1", proxy.SomeVeryExpensiveDataActivity());
        Assert.AreEqual("data-1", proxy.SomeVeryExpensiveDataActivity());
        Assert.AreEqual(1, source.FetchCount);

        source.IsDirty = true;
        Assert.AreEqual("data-2", proxy.SomeVeryExpensiveDataActivity());
        Assert.AreEqual(2, source.FetchCount);
    }

    [TestMethod]
    public void AnimalFactoriesRejectUnknownTypes()
    {
        Assert.ThrowsException<ArgumentException>(() => new PetAnimalFactory().CreateAnimal("unicorn"));
        Assert.ThrowsException<ArgumentException>(() => new AnimalFactoryAbstract().GetFactory("unknown"));
    }

    [TestMethod]
    public void MediatorRelaysMessagesToOtherRegisteredColleagues()
    {
        var mediator = new ConcreteMediator();
        var sender = new TestColleague("Sender");
        var recipient = new TestColleague("Recipient");
        mediator.Register(sender);
        mediator.Register(recipient);

        mediator.SendMessage("hello", sender);

        Assert.AreEqual("hello", recipient.LastReceivedMessage);
        Assert.IsNull(sender.LastReceivedMessage);
    }

    [TestMethod]
    public void UserDefinedConversionAdaptsSquarePegToRoundPeg()
    {
        RoundPegValue roundPeg = (RoundPegValue)new SquarePegValue(4);

        Assert.AreEqual(2 * Math.Sqrt(2), roundPeg.Radius, 0.0001);
    }

    [TestMethod]
    public void ObjectInitializerCreatesSimpleBuilderProduct()
    {
        var house = new SimpleHouseOptions { Foundation = "Concrete", Walls = "Brick", Roof = "Tile" };

        Assert.AreEqual("Brick", house.Walls);
    }

    [TestMethod]
    public void ActionDelegateCanRepresentAndExecuteCommand()
    {
        int executions = 0;

        DelegateCommandAlternative.Execute(() => executions++);

        Assert.AreEqual(1, executions);
    }

    [TestMethod]
    public void FactoryDelegateCreatesRequestedProduct()
    {
        Assert.AreEqual("Bark Bark", FactoryDelegateAlternative.Create<IAnimal>(() => new Dog()).Speak());
    }

    [TestMethod]
    public void ExpressionTreeEvaluatesExpression()
    {
        Assert.AreEqual(5, ExpressionTreeAlternative.Evaluate(() => 2 + 3));
    }

    [TestMethod]
    public void YieldIteratorCanBeConsumedWithForeach()
    {
        var values = new List<int>();
        foreach (int value in YieldIteratorAlternative.CountFrom(3, 3))
        {
            values.Add(value);
        }

        CollectionAssert.AreEqual(new[] { 3, 4, 5 }, values);
    }

    [TestMethod]
    public void RecordSnapshotRestoresEditorState()
    {
        var editor = new RecordSnapshotAlternative();
        editor.Write("saved");
        EditorSnapshot snapshot = editor.Save();
        editor.Write(" changes");
        editor.Restore(snapshot with { Text = "restored" });

        Assert.AreEqual("restored", editor.Text);
    }

    [TestMethod]
    public void EventObserverNotifiesSubscribers()
    {
        var publisher = new EventObserverAlternative();
        string? received = null;
        publisher.MessagePublished += (_, eventArgs) => received = eventArgs.Message;

        publisher.Publish("event");

        Assert.AreEqual("event", received);
    }

    [TestMethod]
    public void DispatchProxyForwardsCallsToTarget()
    {
        var target = new CountingDataSource();
        IDataSource proxy = DispatchProxyAlternative.Wrap(target);

        Assert.AreEqual("data-1", proxy.SomeVeryExpensiveDataActivity());
        Assert.AreEqual(1, target.FetchCount);
    }

    [TestMethod]
    public void StaticClassProvidesOneGlobalServiceIdentity()
    {
        Assert.AreEqual(StaticClassAlternative.ServiceId, StaticClassAlternative.ServiceId);
    }

    [TestMethod]
    public void EnumSwitchModelsSimpleStateTransitions()
    {
        var state = new SwitchStateAlternative();

        Assert.AreEqual(PlaybackState.Playing, state.Toggle());
        Assert.AreEqual(PlaybackState.Stopped, state.Toggle());
    }

    [TestMethod]
    public void DelegateStrategyCanBeChangedAtRuntime()
    {
        var context = new DelegateStrategyAlternative<int, int>(value => value * 2);
        Assert.AreEqual(10, context.Execute(5));

        context.SetStrategy(value => value + 1);

        Assert.AreEqual(6, context.Execute(5));
    }

    [TestMethod]
    public void PatternMatchingCalculatesAreasForClosedShapeSet()
    {
        double area = PatternMatchingAlternative.Area(new CircleValue(2))
            + PatternMatchingAlternative.Area(new RectangleValue(3, 4));

        Assert.AreEqual(Math.PI * 4 + 12, area, 0.0001);
    }

    [TestMethod]
    public void UndoRedoHistoryRestoresAndReappliesTextEdits()
    {
        var document = new TextDocument();
        var history = new UndoRedoHistory();
        history.Execute(new InsertTextCommand(document, 0, "Hello"));
        history.Execute(new InsertTextCommand(document, 5, " world"));

        Assert.AreEqual("Hello world", document.Text);
        Assert.IsTrue(history.Undo());
        Assert.AreEqual("Hello", document.Text);
        Assert.IsTrue(history.Redo());
        Assert.AreEqual("Hello world", document.Text);
    }

    [TestMethod]
    public void DeleteCommandRestoresRemovedTextOnUndo()
    {
        var document = new TextDocument();
        var history = new UndoRedoHistory();
        history.Execute(new InsertTextCommand(document, 0, "Hello world"));
        history.Execute(new DeleteTextCommand(document, 5, 6));

        Assert.AreEqual("Hello", document.Text);
        Assert.IsTrue(history.Undo());
        Assert.AreEqual("Hello world", document.Text);
        Assert.IsTrue(history.Redo());
        Assert.AreEqual("Hello", document.Text);
    }

    [TestMethod]
    public void NewCommandAfterUndoClearsRedoHistory()
    {
        var document = new TextDocument();
        var history = new UndoRedoHistory();
        history.Execute(new InsertTextCommand(document, 0, "first"));
        history.Undo();
        history.Execute(new InsertTextCommand(document, 0, "second"));

        Assert.AreEqual("second", document.Text);
        Assert.IsFalse(history.Redo());
    }

    [TestMethod]
    public void EmptyUndoRedoHistoryReturnsFalse()
    {
        var history = new UndoRedoHistory();

        Assert.IsFalse(history.Undo());
        Assert.IsFalse(history.Redo());
    }

    private sealed class CountingDataSource : IDataSource
    {
        public int FetchCount { get; private set; }
        public bool IsDirty { get; set; }

        public string SomeVeryExpensiveDataActivity() => $"data-{++FetchCount}";
        public bool Dirty() => IsDirty;
    }

    private sealed class TestColleague(string name) : IColleague
    {
        public string Name { get; } = name;
        public string? LastReceivedMessage { get; private set; }
        public void Send(string message) { }
        public void Receive(string message) => LastReceivedMessage = message;
    }
}
