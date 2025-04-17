// See https://aka.ms/new-console-template for more information
using CSC360DemoDesignPatterns.State;
using System.Diagnostics;
using System.Management;




internal class Program {
  private static void Main(string[] args) {
    Context stateContext = new Context(new Cassette());

    Console.WriteLine(stateContext.PlayMusic());

    Thread.Sleep(20000);
    KillSpotify();
    Thread.Sleep(2000);

    stateContext.SetContext(new AMRadio());

    Console.WriteLine(stateContext.PlayMusic());

    Thread.Sleep(20000);
    KillSpotify();
    Thread.Sleep(2000);

    stateContext.SetContext(new FMRadio());

    Console.WriteLine(stateContext.PlayMusic());

    Thread.Sleep(20000);
    KillSpotify();
    Thread.Sleep(2000);

    stateContext.SetContext(new CD());

    Console.WriteLine(stateContext.PlayMusic());

    Thread.Sleep(20000);
    KillSpotify();
    Thread.Sleep(2000);




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