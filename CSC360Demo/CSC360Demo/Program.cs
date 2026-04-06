// See https://aka.ms/new-console-template for more information
using CSC360Demo;
using CSC360DemoDesignPatterns.AbstractFactory;
using CSC360DemoDesignPatterns.Adapter;
using CSC360DemoDesignPatterns.Bridge;
using CSC360DemoDesignPatterns.Command;
using CSC360DemoDesignPatterns.Composite;
using CSC360DemoDesignPatterns.Decorator;
using CSC360DemoDesignPatterns.Facade;
using CSC360DemoDesignPatterns.Factory;
using CSC360DemoDesignPatterns.Flyweight;
using CSC360DemoDesignPatterns.Iterator;
using CSC360DemoDesignPatterns.Mediator;
using CSC360DemoDesignPatterns.Observer;
using CSC360DemoDesignPatterns.Proxy;
using CSC360DemoDesignPatterns.Singleton;
using CSC360DemoDesignPatterns.State;
using CSC360DemoDesignPatterns.Strategy;
using System.Diagnostics;
using System.Management;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Unity;
using Unity.Lifetime;




internal class Program {
    private static void Main(string[] args) {


        //Composite Pattern
        //RtsGame myRtsGame = new RtsGame();

        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine("Attacking with Single Unit");
        //myRtsGame.LeafAlone.Attack();
        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine("Attacking with Group Unit");
        //myRtsGame.CompositeGroup.Attack();
        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine("Adding An Additonal Unit to Group Unit");
        //myRtsGame.CompositeGroup.Add(new UnitLeaf());
        //Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine("Attacking with Group Unit After Adding Another Unit");
        //myRtsGame.CompositeGroup.Attack();

        //Command Pattern

        ICharacter character = new CharacterReceiver();
        ICommandInterface jumpCommand = new JumpCommand(character);
        ICommandInterface attackCommand = new AttackCommand(character);
        ICommandInterface crouchCommand = new CrouchCommand(character);
        ICommandInterface dashCommand = new DashCommand(character);

        XboxControllerInvoker xboxController = new XboxControllerInvoker();

        xboxController.SetCommand("Y", jumpCommand);
        xboxController.SetCommand("B", attackCommand);
        xboxController.SetCommand("X", dashCommand);
        xboxController.SetCommand("A", crouchCommand);

        Console.WriteLine("Press A, B, X, or Y (or Q to quit):");

        while (true) {
            String pressedKey = Console.ReadKey(true).Key.ToString().ToUpper();

            if (pressedKey == "Q") {
                break;
            }

            xboxController.PressButton(pressedKey);
        }






        //Mediator



        //IChatMediator mediator = new ConcreteMediator();

        //IColleague alice = new ConcreteColleague(mediator, "Alice") as IColleague;
        //IColleague bob = new ConcreteColleague(mediator, "Bob") as IColleague;
        //IColleague charlie = new ConcreteColleague(mediator, "Charlie") as IColleague;

        //alice.Send("Hello, team!");
        //bob.Send("Hi Alice!");


        //Decorator
        //PlainText initalText = new PlainText();
        //Console.WriteLine(initalText.Render());
        //ItalicDecorator italicText = new ItalicDecorator(initalText);

        //Console.WriteLine(italicText.Render());

        //BoldDecorator boldText = new BoldDecorator(italicText);

        //Console.WriteLine(boldText.Render());




        //Proxy

        //IDataSource myDataSource = new ProxySource(new ActualSource());

        //for (int requestNumber = 0; requestNumber < 20; requestNumber++) {
        //    Console.WriteLine($"Request Number {requestNumber} result {myDataSource.SomeVeryExpensiveDataActivity()}");
        //    Thread.Sleep(1000);
        //}


        //Flyweight

        //List<CombatUnit> units = new List<CombatUnit>();

        //FlyweightFactory factory = new FlyweightFactory();

        //units.Add(new CombatUnit("Chuck The Sniper", factory.GetFlyweightSoliderType("Sniper")));

        //units.Add(new CombatUnit("Jim The Infantry", factory.GetFlyweightSoliderType("Infantry")));

        //units.Add(new CombatUnit("Bob The The Gunner", factory.GetFlyweightSoliderType("Gunner")));

        //units.Add(new CombatUnit("Richard The The Infantry", factory.GetFlyweightSoliderType("Gunner")));


        //foreach (CombatUnit unit in units) {
        //    Console.WriteLine($"Combat unit named {unit.Name} has an OS : {unit.SoldierTypeCommon.OffensiveStrength} and DS : {unit.SoldierTypeCommon.DefensiveStrength}");
        //}

        //Console.WriteLine("Upgrading Infantry.");
        //factory.GetFlyweightSoliderType("Infantry").OffensiveStrength++;
        //factory.GetFlyweightSoliderType("Infantry").DefensiveStrength++;

        //foreach (CombatUnit unit in units) {
        //    Console.WriteLine($"Combat unit named {unit.Name} has an OS : {unit.SoldierTypeCommon.OffensiveStrength} and DS : {unit.SoldierTypeCommon.DefensiveStrength}");
        //}

        //Iterator


        //// Create a collection
        //ConcreteCollection<int> collection = new ConcreteCollection<int>(new[] { 1, 2, 3, 4, 5 });

        //// Create an iterator
        //IIterator<int> iterator = collection.CreateIterator();

        //// Iterate through the collection
        //while (iterator.MoveNext()) {
        //  Console.WriteLine(iterator.Current);
        //}

        //List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

        //foreach (int item in list.Where(x => x%2 == 0)) { 
        //  Console.WriteLine(item);
        //}


        //Observer
        //IPublisher publisher = new ConcretePublisher();
        //ISubscriber observerOne = new ConcreteObserverOne();
        //ISubscriber observerTwo = new ConcreteObserverTwo();
        //ISubscriber observerThree = new ConcreteObserverThree();
        //ISubscriber observerTwoTwo = new ConcreteObserverTwo();

        //Console.WriteLine("Registering Observer One.");
        //publisher.RegisterSubscriber(observerOne);
        //Console.WriteLine("Registering Observer Two.");
        //publisher.RegisterSubscriber(observerTwo);
        //Console.WriteLine("Registering Observer Three.");
        //publisher.RegisterSubscriber(observerThree);
        //Console.WriteLine("Registering Observer Two Two.");
        //publisher.RegisterSubscriber(observerTwoTwo);
        //String lastText = "";
        //while (lastText.ToUpper() != "EXIT") {
        //    Console.WriteLine("Enter new state :");
        //    lastText = Console.ReadLine();
        //    publisher.Publish(lastText);
        //}

        //Console.WriteLine("Unregistering Observer One.");
        //publisher.UnregisterSubscriber(observerOne);
        //Console.WriteLine("Calling Publish With PublishAll so you can see observer one unregistered");
        //publisher.Publish("PublishAll");
        //publisher.UnregisterSubscriber(observerTwo);


        //Bridge
        //IColor color = new MagentaColor();
        //IShape shape = new Circle(color);

        //shape.Draw();


        //Strategy Pattern

        //Console.WriteLine("Building Blue Team AI...");
        //IAIOpponent blueOpponent = new AIOpponent(new DefensiveStrategy());

        //Console.WriteLine("Blue Team Is Attacking.");
        //blueOpponent.Attack();

        //Console.WriteLine("Blue Opponent is changing strategy");
        //blueOpponent.SetStrategy(new BalancedStrategy());

        //Console.WriteLine("Blue Team Is Attacking.");
        //blueOpponent.Attack();

        //Console.WriteLine("Blue Opponent is changing strategy");
        //blueOpponent.SetStrategy(new AgressiveStrategy());

        //Console.WriteLine("Blue Team Is Attacking.");
        //blueOpponent.Attack();

        //Adapter Pattern
        //IRoundPeg roundPeg = new RoundPeg(3);
        //ISquarePeg square = new SquarePeg(2);
        //IRoundPeg adaptedPeg = new SquarePegAdapter(square);

        //Console.WriteLine($"Round Peg's radius is {roundPeg.GetRadius().ToString()}");
        //Console.WriteLine($"The Square peg's width is {square.GetWidth().ToString()}");
        //Console.WriteLine($"Square Peg's radius is {adaptedPeg.GetRadius().ToString()}");



        //State Pattern

        //IDemoFacade demoFacade = new DemoFacade();

        //Context stateContext = new Context(new Cassette());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();

        //stateContext = new Context(new Player45());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();

        //stateContext = new Context(new CassetteTwo());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();

        //stateContext.SetContext(new AMRadio());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();

        //stateContext.SetContext(new FMRadio());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();

        //stateContext.SetContext(new CD());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();

        //stateContext.SetContext(new MP3Player());

        //Console.WriteLine(stateContext.PlayMusic());

        //Thread.Sleep(20000);
        //demoFacade.SpotifyFacade.Value.KillSpotify();




        //AnimalFactoryAbstract abstractFactory = new AnimalFactoryAbstract();

        //IAnimalFactory factory = abstractFactory.GetFactory("wild");


        //IAnimal talkingAnimal = factory.CreateAnimal("dog");

        //Console.WriteLine(talkingAnimal.Speak());



        //talkingAnimal = factory.CreateAnimal("cat");

        //Console.WriteLine(talkingAnimal.Speak());

        //talkingAnimal = factory.CreateAnimal("bird");

        //Console.WriteLine(talkingAnimal.Speak());

        //talkingAnimal = factory.CreateAnimal("turtle");

        //Console.WriteLine(talkingAnimal.Speak());


        //talkingAnimal = factory.CreateAnimal("parrot");

        //Console.WriteLine(talkingAnimal.Speak());

        //IUnityContainer iocContainer = new UnityContainer();
        //iocContainer.RegisterType<ISingletonForIoc, SingletonForIoc>(new ContainerControlledLifetimeManager());
        //iocContainer.RegisterType<IProgramShell, SingletonProgramShell>(new TransientLifetimeManager());

        //Console.WriteLine("Resolving Program Shell");
        //IProgramShell shell = iocContainer.Resolve<IProgramShell>();
        //ISingletonForIoc singleton = iocContainer.Resolve<ISingletonForIoc>();

        //Console.WriteLine($"The Identity of Shell One (Not Singleton) is *****{shell.ShellIdentity}*****");

        //Console.WriteLine($"The GUID from our singleton in our shell is {shell.InvokeTest()}");
        //Console.WriteLine($"The GUID from our stand-alone singelton  is {singleton.InstanceGuid}");

        //Console.WriteLine("Resolving a second instance of shell");
        //Thread.Sleep(1000);
        //IProgramShell shellTwo = iocContainer.Resolve<IProgramShell>();
        //Console.WriteLine($"The Identity of Shell Two (Not Singleton) is ******{shellTwo.ShellIdentity}*****");

        //Console.WriteLine($"The GUID from our singleton in our shell2 is {shellTwo.InvokeTest()}");
        //Console.WriteLine($"The GUID from our stand-alone singelton  is  {shell.InvokeTest()}");
        //SingletonOne mySingletonTwo = SingletonOne.GetInstance();
        //Console.WriteLine(mySingletonTwo.InstanceGuid.ToString());
        //SingletonOne mySingletonTwoToo = SingletonOne.GetInstance();
        //Console.WriteLine(mySingletonTwoToo.InstanceGuid.ToString());

    }
    public static void KillSpotify() {
        // Create a query to find the Spotify process
        string query = "SELECT * FROM Win32_Process WHERE Name='Spotify.exe'";
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

        // Execute the query and close each process
        foreach (ManagementObject obj in searcher.Get()) {
            uint processId = (uint)obj["ProcessId"];
            Process process = Process.GetProcessById((int)processId);
            process.Kill();
        }
        Thread.Sleep(2000);
    }

}
