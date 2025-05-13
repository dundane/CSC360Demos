// See https://aka.ms/new-console-template for more information
using CSC360DemoDesignPatterns.Bridge;
using CSC360DemoDesignPatterns.Flyweight;
using CSC360DemoDesignPatterns.Iterator;
using CSC360DemoDesignPatterns.Observer;
using CSC360DemoDesignPatterns.Proxy;
using CSC360DemoDesignPatterns.State;
using System.Diagnostics;
using System.Management;
using System.Security.Cryptography.X509Certificates;




internal class Program {
  private static void Main(string[] args) {

    //Proxy

    IDataSource myDataSource = new ProxySource(new ActualSource());

    for (int requestNumber = 0; requestNumber < 20; requestNumber++) {
      Console.WriteLine($"Request Number {requestNumber} result {myDataSource.SomeVeryExpensiveDataActivity()}");
      Thread.Sleep(1000);
    }


    //Flyweight

    //List<CombatUnit> units = new List<CombatUnit>();

    //FlyweightFactory factory = new FlyweightFactory();

    //units.Add(new CombatUnit("Chuck The Sniper", factory.GetFlyweightSoliderType("Sniper")));

    //units.Add(new CombatUnit("Jim The Infantry", factory.GetFlyweightSoliderType("Infantry")));

    //units.Add(new CombatUnit("Bob The The Gunner", factory.GetFlyweightSoliderType("Gunner")));

    //units.Add(new CombatUnit("Richard The The Infantry", factory.GetFlyweightSoliderType("Gunner")));


    //foreach (CombatUnit unit in units) {
    //  Console.WriteLine($"Combat unit named {unit.Name} has an OS : {unit.SoldierTypeCommon.OffensiveStrength} and DS : {unit.SoldierTypeCommon.DefensiveStrength}");
    //}

    //Console.WriteLine("Upgrading Infantry.");
    //factory.GetFlyweightSoliderType("Infantry").OffensiveStrength++;
    //factory.GetFlyweightSoliderType("Infantry").DefensiveStrength++;

    //foreach (CombatUnit unit in units) {
    //  Console.WriteLine($"Combat unit named {unit.Name} has an OS : {unit.SoldierTypeCommon.OffensiveStrength} and DS : {unit.SoldierTypeCommon.DefensiveStrength}");
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

    //publisher.RegisterSubscriber(observerOne);
    //publisher.RegisterSubscriber(observerTwo);
    //publisher.RegisterSubscriber(observerThree);
    //publisher.RegisterSubscriber(observerTwoTwo);
    //String lastText = "";
    //while (lastText.ToUpper() != "EXIT") {
    //  Console.WriteLine("Enter new state :");
    //  lastText = Console.ReadLine();
    //  publisher.Publish(lastText);
    //}

    //Console.WriteLine("Unregistering Observer One.");
    //publisher.UnregisterSubscriber(observerOne);
    //Console.WriteLine("Calling Publish With PublishAll so you can see observer one unregistered");
    //publisher.Publish("PublishAll");
    //publisher.UnregisterSubscriber(observerTwo);


    //Bridge
    //IColor color = new PinkColor();
    //IShape shape = new Arrow(color);

    //shape.Draw();





    //Context stateContext = new Context(new Cassette());

    //Console.WriteLine(stateContext.PlayMusic());

    //Thread.Sleep(20000);
    //KillSpotify();
    //Thread.Sleep(2000);

    //stateContext.SetContext(new AMRadio());

    //Console.WriteLine(stateContext.PlayMusic());

    //Thread.Sleep(20000);
    //KillSpotify();
    //Thread.Sleep(2000);

    //stateContext.SetContext(new FMRadio());

    //Console.WriteLine(stateContext.PlayMusic());

    //Thread.Sleep(20000);
    //KillSpotify();
    //Thread.Sleep(2000);

    //stateContext.SetContext(new CD());

    //Console.WriteLine(stateContext.PlayMusic());

    //Thread.Sleep(20000);
    //KillSpotify();
    //Thread.Sleep(2000);




    //AnimalFactoryAbstract abstractFactory = new AnimalFactoryAbstract();





    //IAnimalFactory factory = abstractFactory.GetFactory("PET");

    ////PetAnimalFactory factory = new PetAnimalFactory();

    //IAnimal talkingAnimal = factory.CreateAnimal("dog");

    //Console.WriteLine(talkingAnimal.Speak());



    //talkingAnimal = factory.CreateAnimal("cat");

    //Console.WriteLine(talkingAnimal.Speak());

    //talkingAnimal = factory.CreateAnimal("bird");

    //Console.WriteLine(talkingAnimal.Speak());

    //talkingAnimal = factory.CreateAnimal("turtle");

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
    //Thread.Sleep( 1000 );
    //IProgramShell shellTwo = iocContainer.Resolve<IProgramShell>();
    //Console.WriteLine($"The Identity of Shell Two (Not Singleton) is ******{shellTwo.ShellIdentity}*****");

    //Console.WriteLine($"The GUID from our singleton in our shell2 is {shellTwo.InvokeTest()}");
    //Console.WriteLine($"The GUID from our stand-alone singelton  is  {shell.InvokeTest()}");

  }
  static void KillSpotify() {


    // Create a query to find the Spotify process
    string query = "SELECT * FROM Win32_Process WHERE Name='Spotify.exe'";
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

    // Execute the query and close each process
    foreach (ManagementObject obj in searcher.Get()) {
      uint processId = (uint)obj["ProcessId"];
      Process process = Process.GetProcessById((int)processId);
      process.Kill();
    }
  }
}