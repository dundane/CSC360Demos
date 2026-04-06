using SingletonBridgeCommandDemo.Singleton;

internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine($"Your Random Number is {RandomSingleton.Instance.Next(1,10)}");
    }
}