using CSC360DemoDesignPatterns.AbstractFactory;
using CSC360DemoDesignPatterns.Adapter;
using CSC360DemoDesignPatterns.Bridge;
using CSC360DemoDesignPatterns.Builder;
using CSC360DemoDesignPatterns.ChainOfResponsibility;
using CSC360DemoDesignPatterns.Command;
using CSC360DemoDesignPatterns.Command.UndoRedoDemo;
using CSC360DemoDesignPatterns.Composite;
using CSC360DemoDesignPatterns.Decorator;
using CSC360DemoDesignPatterns.Facade;
using CSC360DemoDesignPatterns.Factory;
using CSC360DemoDesignPatterns.FactoryMethod;
using CSC360DemoDesignPatterns.Flyweight;
using CSC360DemoDesignPatterns.Interpreter;
using CSC360DemoDesignPatterns.Iterator;
using CSC360DemoDesignPatterns.Mediator;
using CSC360DemoDesignPatterns.Memento;
using CSC360DemoDesignPatterns.Observer;
using CSC360DemoDesignPatterns.Prototype;
using CSC360DemoDesignPatterns.Proxy;
using CSC360DemoDesignPatterns.Singleton;
using CSC360DemoDesignPatterns.State;
using CSC360DemoDesignPatterns.Strategy;
using CSC360DemoDesignPatterns.TemplateMethod;
using CSC360DemoDesignPatterns.Visitor;
using CSC360DemoDesignPatterns.Week1.Solid;
using CSC360Demo.InteractiveDemos;
using BridgeCircle = CSC360DemoDesignPatterns.Bridge.Circle;
using VisitorCircle = CSC360DemoDesignPatterns.Visitor.Circle;

namespace CSC360Demo;

internal static class DemoFactory
{
    public static IReadOnlyList<IDemoStrategy> CreatePatternDemos() =>
    [
        Create("Abstract Factory", () => Console.WriteLine(new AnimalFactoryAbstract().GetFactory("wild").CreateAnimal("dog").Speak())),
        Create("Adapter", () => Console.WriteLine($"Square peg radius: {new SquarePegAdapter(new SquarePeg(4)).GetRadius():F2}")),
        Create("Bridge", () => new BridgeCircle(new RedColor()).Draw()),
        Create("Builder", () => Console.WriteLine(new HouseDirector().BuildFamilyHouse(new ConcreteHouseBuilder()))),
        Create("Chain of Responsibility", () =>
        {
            var handler = new BillingSupportHandler();
            handler.SetNext(new TechnicalSupportHandler());
            Console.WriteLine(handler.Handle(new SupportRequest("technical", "Cannot sign in")));
        }),
        Create("Command", () =>
        {
            var controller = new XboxControllerInvoker();
            controller.SetCommand("A", new JumpCommand(new CharacterReceiver()));
            controller.PressButton("A");
        }),
        Create("Command — undo and redo", UndoRedoWalkthrough.Run),
        Create("Composite", () => new RtsGame().CompositeGroup.Attack()),
        Create("Decorator", () => Console.WriteLine(new BoldDecorator(new ItalicDecorator(new PlainText())).Render())),
        Create("Facade", () => Console.WriteLine(new HomeTheaterFacade().WatchMovie("A demo movie"))),
        Create("Factory Method", () => Console.WriteLine(new DogShelter().AdoptAnimal())),
        Create("Flyweight", () =>
        {
            var factory = new FlyweightFactory();
            Console.WriteLine($"Shared infantry state: {ReferenceEquals(factory.GetFlyweightSoliderType("Infantry"), factory.GetFlyweightSoliderType("Infantry"))}");
        }),
        Create("Interpreter", () =>
        {
            IExpression expression = new AddExpression(new VariableExpression("x"), new NumberExpression(3));
            Console.WriteLine(expression.Interpret(new Dictionary<string, int> { ["x"] = 4 }));
        }),
        Create("Iterator", () =>
        {
            IIterator<int> iterator = new ConcreteCollection<int>([1, 2, 3]).CreateIterator();
            while (iterator.MoveNext()) Console.WriteLine(iterator.Current);
        }),
        Create("Mediator", () =>
        {
            IChatMediator mediator = new ConcreteMediator();
            IColleague alice = new ConcreteColleague(mediator, "Alice");
            IColleague bob = new ConcreteColleague(mediator, "Bob");
            mediator.Register(alice);
            mediator.Register(bob);
            alice.Send("Hello, Bob!");
        }),
        Create("Memento", () =>
        {
            var editor = new TextEditor();
            var history = new EditorHistory();
            editor.Write("before ");
            history.Save(editor);
            editor.Write("undo");
            history.Undo(editor);
            Console.WriteLine(editor.Text);
        }),
        Create("Observer", () =>
        {
            var publisher = new ConcretePublisher();
            publisher.RegisterSubscriber(new ConcreteObserverTwo());
            publisher.Publish("StateOne");
        }),
        Create("Prototype", () =>
        {
            var original = new GameCharacter("Ranger", 100, ["Bow"]);
            GameCharacter copy = original.Clone();
            copy.Equipment.Add("Cloak");
            Console.WriteLine($"Original: {string.Join(", ", original.Equipment)}; clone: {string.Join(", ", copy.Equipment)}");
        }),
        Create("Proxy", () =>
        {
            IDataSource source = new ProxySource(new StableDataSource());
            Console.WriteLine(source.SomeVeryExpensiveDataActivity());
            Console.WriteLine(source.SomeVeryExpensiveDataActivity());
        }),
        Create("Singleton", () => Console.WriteLine(SingletonOne.GetInstance().InstanceGuid)),
        Create("State", () =>
        {
            var context = new Context();
            context.SetContext(new DemoMusicSource());
            Console.WriteLine(context.PlayMusic());
        }),
        Create("Strategy", () => new AIOpponent(new BalancedStrategy()).Attack()),
        Create("Template Method", () => Console.WriteLine(new CsvDataMiner().Mine("name,score\nAda,100\n"))),
        Create("Visitor", () =>
        {
            var visitor = new AreaVisitor();
            new IShapeElement[] { new VisitorCircle(2), new Rectangle(3, 4) }.ToList().ForEach(shape => shape.Accept(visitor));
            Console.WriteLine($"Combined area: {visitor.TotalArea:F2}");
        }),
        Create("C# Adapter — user-defined conversion", () =>
        {
            RoundPegValue peg = (RoundPegValue)new SquarePegValue(4);
            Console.WriteLine($"Converted radius: {peg.Radius:F2}");
        }),
        Create("C# Builder — object initializer", () => Console.WriteLine(new SimpleHouseOptions { Foundation = "Concrete", Walls = "Brick", Roof = "Tile" })),
        Create("C# Command — Action delegate", () => DelegateCommandAlternative.Execute(() => Console.WriteLine("Lambda command executed"))),
        Create("C# Factory Method — Func<T>", () => Console.WriteLine(FactoryDelegateAlternative.Create<IAnimal>(() => new Dog()).Speak())),
        Create("C# Interpreter — expression tree", () => Console.WriteLine(ExpressionTreeAlternative.Evaluate(() => 2 + 3))),
        Create("C# Iterator — yield and foreach", () =>
        {
            foreach (int value in YieldIteratorAlternative.CountFrom(1, 3)) Console.WriteLine(value);
        }),
        Create("C# Memento — record snapshot", () =>
        {
            var editor = new RecordSnapshotAlternative();
            editor.Write("saved");
            EditorSnapshot snapshot = editor.Save();
            editor.Write(" changes");
            editor.Restore(snapshot);
            Console.WriteLine(editor.Text);
        }),
        Create("C# Observer — event", () =>
        {
            var publisher = new EventObserverAlternative();
            publisher.MessagePublished += (_, args) => Console.WriteLine(args.Message);
            publisher.Publish("Event delivered");
        }),
        Create("C# Prototype — record with-expression", () => Console.WriteLine(new CharacterSnapshot("Ranger", 100).CloneWithHealth(75))),
        Create("C# Proxy — DispatchProxy", () => Console.WriteLine(DispatchProxyAlternative.Wrap(new StableDataSource()).SomeVeryExpensiveDataActivity())),
        Create("C# Singleton — static class", () => Console.WriteLine(StaticClassAlternative.ServiceId)),
        Create("C# State — enum and switch", () =>
        {
            var state = new SwitchStateAlternative();
            Console.WriteLine(state.Toggle());
            Console.WriteLine(state.Toggle());
        }),
        Create("C# Strategy — delegate", () =>
        {
            var strategy = new DelegateStrategyAlternative<int, int>(value => value * 2);
            Console.WriteLine(strategy.Execute(5));
            strategy.SetStrategy(value => value + 1);
            Console.WriteLine(strategy.Execute(5));
        }),
        Create("C# Visitor — pattern matching", () =>
        {
            double area = PatternMatchingAlternative.Area(new CircleValue(2)) + PatternMatchingAlternative.Area(new RectangleValue(3, 4));
            Console.WriteLine($"Combined area: {area:F2}");
        })
    ];

    public static IReadOnlyList<IDemoStrategy> CreateMenuDemos()
    {
        var demos = new List<IDemoStrategy>
        {
            Create("Run all GoF and C# examples", PatternDemoRunner.RunAll)
        };
        demos.AddRange(CreatePatternDemos());
        demos.Add(Create("Week 1 — run all SOLID examples", SolidTeachingExamples.RunAll));
        demos.Add(Create("SOLID — Single Responsibility", SolidTeachingExamples.RunSingleResponsibility));
        demos.Add(Create("SOLID — Open/Closed", SolidTeachingExamples.RunOpenClosed));
        demos.Add(Create("SOLID — Liskov Substitution", SolidTeachingExamples.RunLiskovSubstitution));
        demos.Add(Create("SOLID — Interface Segregation", SolidTeachingExamples.RunInterfaceSegregation));
        demos.Add(Create("SOLID — Dependency Inversion", SolidTeachingExamples.RunDependencyInversion));
        demos.Add(Create("SOLID — integrated workflow", SolidTeachingExamples.RunIntegratedWorkflow));

        var interactiveSessions = InteractiveDemoDiscovery.CreateSessions();
        var interactiveNames = interactiveSessions.Select(session => session.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
        demos.RemoveAll(demo => interactiveNames.Contains(demo.Name));
        demos.AddRange(interactiveSessions.Select(session => (IDemoStrategy)new InteractiveDemoStrategy(session)));
        return demos.OrderBy(demo => demo.Name, StringComparer.OrdinalIgnoreCase).ToArray();
    }

    private static IDemoStrategy Create(string name, Action action) =>
        new DelegateDemoStrategy(name, () =>
        {
            Console.WriteLine($"\n{name}");
            foreach (string call in DemoCallTraceCatalog.GetCalls(name))
            {
                Console.WriteLine($"  -> {call}");
            }

            action();
        });

    private sealed class StableDataSource : IDataSource
    {
        public string SomeVeryExpensiveDataActivity() => "Stable demo data";
        public bool Dirty() => false;
    }

}
