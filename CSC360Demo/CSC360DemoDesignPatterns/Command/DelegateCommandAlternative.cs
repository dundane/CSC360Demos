namespace CSC360DemoDesignPatterns.Command;

public static class DelegateCommandAlternative
{
    public static void Execute(Action command)
    {
        ArgumentNullException.ThrowIfNull(command);
        command();
    }
}
