# CSC360 Design Pattern Demos

This .NET 8 solution contains runnable examples of the 23 Gang of Four (GoF) design patterns. The implementations are intended for classroom demonstration: each pattern is represented by small types with a focused responsibility, and the console runner exercises each one.

## Run the demos

From the directory containing `CSC360Demo.sln`:

Run the application without arguments to open the interactive menu. Use the Up/Down arrows to select a demo, Enter to run it, and Esc or Q to quit. The menu is backed by a factory-created catalog of demo strategies. Pattern sessions accept text commands; type `help` for session commands and `menu` to return to the main menu. One-shot demos return directly to the menu.

Interactive pattern commands include:

| Session | Example commands |
| --- | --- |
| Abstract Factory | `families`, `family wild`, `list`, `animal dog`, `speak` |
| Bridge | `list`, `shape Circle`, `color Red`, `draw` |
| Strategy | `list`, `use BalancedStrategy`, `attack` |
| State | `list`, `use DemoMusicSource`, `play`, `toggle` |
| Decorator | `text Hello`, `list`, `add BoldDecorator`, `render`, `clear` |
| Command | `list`, `press Jump` |
| Iterator | `list`, `add delta`, `iterate` |
| Observer | `list`, `add ConcreteObserverOne`, `publish StateTwo`, `remove ConcreteObserverOne` |
| Chain of Responsibility | `list`, `request billing Please review my invoice` |

Interactive sessions and pattern variations are discovered from concrete implementations at runtime. New classes can participate by implementing the relevant pattern interface, using constructors supported by the session (for example, a parameterless Strategy or a Bridge shape with an `IColor` constructor), and placing animal products in the corresponding factory namespace. The State session intentionally discovers only `IInteractiveBoomBoxSource` implementations so selecting a source cannot launch an external media application.

Run the Week 1 SOLID examples directly with:

```powershell
dotnet run --project CSC360Demo/CSC360Demo.csproj -- --solid
```

Run all GoF patterns and C# alternatives directly with:

```powershell
dotnet run --project CSC360Demo/CSC360Demo.csproj -- --all-patterns
```

The examples use console output and do not launch external applications. Each selected demo prints a curated `source file :: method` call flow before the corresponding example output; these are teaching traces, not runtime stack traces. When input is redirected, the application lists menu choices instead of trying to read arrow keys.

Run the test suite with:

```powershell
dotnet test CSC360Demo.sln
```

## GoF pattern inventory

### Creational

| Pattern | Example |
| --- | --- |
| Abstract Factory | `AbstractFactory/AnimalFactoryAbstract`, `IAnimalFactory`, `WildAnimalFactory` |
| Builder | `Builder/IHouseBuilder`, `ConcreteHouseBuilder`, `HouseDirector` |
| Factory Method | `FactoryMethod/AnimalShelter`, `DogShelter`, `CatShelter` |
| Prototype | `Prototype/GameCharacter.Clone` |
| Singleton | `Singleton/SingletonOne` and `SingletonTwo` |

### Structural

| Pattern | Example |
| --- | --- |
| Adapter | `Adapter/SquarePegAdapter` |
| Bridge | `Bridge/IShape` and `IColor` implementations |
| Composite | `Composite/IGameUnit`, `UnitLeaf`, `UnitGroup` |
| Decorator | `Decorator/TextDecoratorBase`, `BoldDecorator`, `ItalicDecorator` |
| Facade | `Facade/HomeTheaterFacade` and `SpotifyFacade` |
| Flyweight | `Flyweight/FlyweightFactory`, `IFlyweightSoldier` implementations |
| Proxy | `Proxy/ProxySource` and `ActualSource` |

### Behavioral

| Pattern | Example |
| --- | --- |
| Chain of Responsibility | `ChainOfResponsibility/SupportHandler` implementations |
| Command | `Command/ICommandInterface`, command types, `XboxControllerInvoker`; `Command/UndoRedoDemo` shows reversible commands and history |
| Interpreter | `Interpreter/IExpression` and expression types |
| Iterator | `Iterator/ConcreteCollection`, `ConcreteIterator` |
| Mediator | `Mediator/ConcreteMediator`, `ConcreteColleague` |
| Memento | `Memento/TextEditor`, `EditorHistory`, `TextEditorMemento` |
| Observer | `Observer/ConcretePublisher`, `ISubscriber` implementations |
| State | `State/Context` and `IBoomBoxSource` implementations |
| Strategy | `Strategy/AIOpponent` and `IAIStrategy` implementations |
| Template Method | `TemplateMethod/DataMiner` and concrete miners |
| Visitor | `Visitor/IShapeVisitor`, shape elements, `AreaVisitor` |

## Related examples

`Factory/PetAnimalFactory` is a simple factory used as a supplementary example; it is not the GoF Factory Method pattern. Factory Method is demonstrated separately under `FactoryMethod/`.

The original Spotify facade interacts with the local operating system. The comprehensive runner uses the self-contained `HomeTheaterFacade` example instead to avoid opening or terminating external applications.

## C#/.NET alternatives

The comprehensive runner also demonstrates the following alternatives in separate files alongside the classic implementations. These are focused substitutes for common/simple cases, not replacements for every capability of the corresponding GoF pattern.

| GoF pattern | C#/.NET alternative | Scope and limitation |
| --- | --- | --- |
| Adapter | `Adapter/CSharpConversionAlternative` | User-defined conversion for a simple value conversion; it is not suitable for adapting complex APIs. |
| Builder | `Builder/ObjectInitializerAlternative` | Object initializers work for simple property-based products, but provide no director or multi-step validation. |
| Command | `Command/DelegateCommandAlternative` | An `Action` represents an executable command, but has no built-in identity, history, or undo. |
| Factory Method | `FactoryMethod/FactoryDelegateAlternative` | `Func<T>` supplies a creator callback without requiring a creator subclass. |
| Interpreter | `Interpreter/ExpressionTreeAlternative` | Expression trees evaluate expressions representable by .NET; they do not replace a parser for an arbitrary grammar. |
| Iterator | `Iterator/YieldIteratorAlternative` | `IEnumerable<T>`, `yield return`, and `foreach` provide language/runtime iteration without a custom iterator type. |
| Memento | `Memento/RecordSnapshotAlternative` | Records provide convenient value snapshots, but the snapshot is not opaque and history management remains separate. |
| Observer | `Observer/EventObserverAlternative` | C# events and `EventHandler<T>` implement publisher/subscriber notification for in-process subscribers. |
| Prototype | `Prototype/RecordPrototypeAlternative` | A record `with` expression makes a shallow copy; nested mutable state still needs explicit copying. |
| Proxy | `Proxy/DispatchProxyAlternative` | `DispatchProxy` creates runtime proxies for interfaces; it is not a general proxy for every type. |
| Singleton | `Singleton/StaticClassAlternative` | Static members can replace a global service when no object instance, interface, or dependency injection is needed. |
| State | `State/SwitchStateAlternative` | An enum and switch are compact for a small finite state machine; complex state behavior is clearer in state objects. |
| Strategy | `Strategy/DelegateStrategyAlternative` | A `Func<TInput, TOutput>` can stand in for interchangeable algorithms. |
| Visitor | `Visitor/PatternMatchingAlternative` | Type-pattern matching is concise for a closed shape set; adding cases centralizes changes in the switch. |

No close built-in substitute is shown for Abstract Factory, Bridge, Chain of Responsibility, Composite, Decorator, Facade, Flyweight, Mediator, or Template Method. These patterns remain useful when their respective object-structure or collaboration needs arise.

## Week 1: SOLID software design

`Week1/Solid` provides independently runnable SRP, OCP, LSP, ISP, and DIP examples using an order and receipt workflow. The final example wires the same abstractions and implementations together for an end-to-end checkout and receipt lookup. Run the full section with `--solid`, or select any individual principle or the integrated workflow from the interactive menu.
