using CSC360Demo;
using CSC360DemoDesignPatterns.Week1.Solid;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Contains("--all-patterns", StringComparer.OrdinalIgnoreCase))
        {
            PatternDemoRunner.RunAll();
            return;
        }

        if (args.Contains("--solid", StringComparer.OrdinalIgnoreCase))
        {
            SolidTeachingExamples.RunAll();
            return;
        }

        ConsoleDemoMenu.Run();
    }
}
