namespace CSC360Demo;

internal static class DemoCallTraceCatalog
{
    private static readonly IReadOnlyDictionary<string, string[]> Calls = new Dictionary<string, string[]>
    {
        ["Run all GoF and C# examples"] = ["PatternDemoRunner.cs :: RunAll"],
        ["Abstract Factory"] = ["AbstractFactory/AnimalFactoryAbstract.cs :: GetFactory", "AbstractFactory/WildAnimalFactory.cs :: CreateAnimal", "AbstractFactory/WildDog.cs :: Speak"],
        ["Adapter"] = ["Adapter/SquarePegAdapter.cs :: GetRadius", "Adapter/SquarePeg.cs :: GetWidth"],
        ["Bridge"] = ["Bridge/Circle.cs :: Draw", "Bridge/RedColor.cs :: ApplyColor"],
        ["Builder"] = ["Builder/HouseDirector.cs :: BuildFamilyHouse", "Builder/HouseBuilder.cs :: BuildFoundation, BuildWalls, BuildRoof, AddDoors, AddWindows, Build"],
        ["Chain of Responsibility"] = ["ChainOfResponsibility/SupportHandler.cs :: SetNext, Handle", "ChainOfResponsibility/SupportHandler.cs :: TechnicalSupportHandler.CanHandle, Resolve"],
        ["Command"] = ["Command/XboxControllerInvoker.cs :: SetCommand, PressButton", "Command/JumpCommand.cs :: Execute", "Command/CharacterReceiver.cs :: Jump"],
        ["Command — undo and redo"] = ["Command/UndoRedoDemo/UndoRedoWalkthrough.cs :: Run"],
        ["Composite"] = ["Composite/UnitGroup.cs :: Attack", "Composite/UnitLeaf.cs :: Attack"],
        ["Decorator"] = ["Decorator/BoldDecorator.cs :: Render", "Decorator/ItalicDecorator.cs :: Render", "Decorator/PlainText.cs :: Render"],
        ["Facade"] = ["Facade/HomeTheaterFacade.cs :: WatchMovie", "Facade/HomeTheaterFacade.cs :: Projector.TurnOn, AudioSystem.Configure, MoviePlayer.Play"],
        ["Factory Method"] = ["FactoryMethod/AnimalShelter.cs :: AdoptAnimal", "FactoryMethod/AnimalShelter.cs :: DogShelter.CreateAnimal", "Factory/Dog.cs :: Speak"],
        ["Flyweight"] = ["Flyweight/FlyweightFactory.cs :: GetFlyweightSoliderType", "Flyweight/ConcreteFlyweightInfantry.cs :: shared flyweight state"],
        ["Interpreter"] = ["Interpreter/Expression.cs :: AddExpression.Interpret", "Interpreter/Expression.cs :: VariableExpression.Interpret, NumberExpression.Interpret"],
        ["Iterator"] = ["Iterator/ConcreteCollection.cs :: CreateIterator", "Iterator/ConcreteIterator.cs :: MoveNext, Current"],
        ["Mediator"] = ["Mediator/ConcreteMediator.cs :: Register", "Mediator/ConcreteColleague.cs :: Send", "Mediator/ConcreteMediator.cs :: SendMessage, RelayMessage", "Mediator/ConcreteColleague.cs :: Receive"],
        ["Memento"] = ["Memento/TextEditor.cs :: Write, Save", "Memento/EditorHistory.cs :: Save, Undo", "Memento/TextEditor.cs :: Restore"],
        ["Observer"] = ["Observer/ConcretePublisher.cs :: RegisterSubscriber, Publish", "Observer/ConcreteObserverTwo.cs :: UpdateState"],
        ["Prototype"] = ["Prototype/GameCharacter.cs :: Clone"],
        ["Proxy"] = ["Proxy/ProxySource.cs :: SomeVeryExpensiveDataActivity", "Proxy/ActualSource.cs :: Dirty, SomeVeryExpensiveDataActivity"],
        ["Singleton"] = ["Singleton/SingletonOne.cs :: GetInstance"],
        ["State"] = ["State/Context.cs :: SetContext, PlayMusic", "DemoFactory.cs :: DemoMusicSource.PlayMuisc, Source"],
        ["Strategy"] = ["Strategy/AIOpponent.cs :: Attack", "Strategy/BalancedStrategy.cs :: Attack"],
        ["Template Method"] = ["TemplateMethod/DataMiner.cs :: Mine, Open, Close", "TemplateMethod/DataMiner.cs :: CsvDataMiner.Extract, Analyze"],
        ["Visitor"] = ["Visitor/ShapeVisitor.cs :: Circle.Accept, Rectangle.Accept", "Visitor/ShapeVisitor.cs :: AreaVisitor.Visit, TotalArea"],
        ["C# Adapter — user-defined conversion"] = ["Adapter/CSharpConversionAlternative.cs :: SquarePegValue.op_Explicit"],
        ["C# Builder — object initializer"] = ["Builder/ObjectInitializerAlternative.cs :: SimpleHouseOptions.init properties"],
        ["C# Command — Action delegate"] = ["Command/DelegateCommandAlternative.cs :: Execute", "DemoFactory.cs :: Action delegate"],
        ["C# Factory Method — Func<T>"] = ["FactoryMethod/FactoryDelegateAlternative.cs :: Create", "Factory/Dog.cs :: Speak"],
        ["C# Interpreter — expression tree"] = ["Interpreter/ExpressionTreeAlternative.cs :: Evaluate, Compile"],
        ["C# Iterator — yield and foreach"] = ["Iterator/YieldIteratorAlternative.cs :: CountFrom", "DemoFactory.cs :: foreach"],
        ["C# Memento — record snapshot"] = ["Memento/RecordSnapshotAlternative.cs :: Write, Save, Restore"],
        ["C# Observer — event"] = ["Observer/EventObserverAlternative.cs :: add_MessagePublished, Publish"],
        ["C# Prototype — record with-expression"] = ["Prototype/RecordPrototypeAlternative.cs :: CloneWithHealth"],
        ["C# Proxy — DispatchProxy"] = ["Proxy/DispatchProxyAlternative.cs :: Wrap, Invoke", "DemoFactory.cs :: IDataSource.SomeVeryExpensiveDataActivity"],
        ["C# Singleton — static class"] = ["Singleton/StaticClassAlternative.cs :: get_ServiceId"],
        ["C# State — enum and switch"] = ["State/SwitchStateAlternative.cs :: Toggle"],
        ["C# Strategy — delegate"] = ["Strategy/DelegateStrategyAlternative.cs :: Execute, SetStrategy"],
        ["C# Visitor — pattern matching"] = ["Visitor/PatternMatchingAlternative.cs :: Area"],
        ["Week 1 — run all SOLID examples"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunAll"],
        ["SOLID — Single Responsibility"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunSingleResponsibility"],
        ["SOLID — Open/Closed"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunOpenClosed"],
        ["SOLID — Liskov Substitution"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunLiskovSubstitution"],
        ["SOLID — Interface Segregation"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunInterfaceSegregation"],
        ["SOLID — Dependency Inversion"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunDependencyInversion"],
        ["SOLID — integrated workflow"] = ["Week1/Solid/SolidTeachingExamples.cs :: RunIntegratedWorkflow"]
    };

    public static IReadOnlyList<string> GetCalls(string demoName) =>
        Calls.TryGetValue(demoName, out string[]? calls) ? calls : [];
}
