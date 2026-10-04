namespace CSC360Demo.InteractiveDemos;

public abstract class InteractiveDemoSessionBase : IInteractiveDemoSession
{
    public abstract string Name { get; }

    public void Run(TextReader input, TextWriter output)
    {
        ArgumentNullException.ThrowIfNull(input);
        ArgumentNullException.ThrowIfNull(output);
        output.WriteLine($"{Name}: type help for commands or menu to return.");

        while (true)
        {
            output.Write($"{Name}> ");
            string? command = input.ReadLine();
            if (command is null)
            {
                return;
            }

            command = command.Trim();
            if (command.Equals("menu", StringComparison.OrdinalIgnoreCase))
            {
                output.WriteLine("Returning to the main menu.");
                return;
            }

            if (command.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                WriteHelp(output);
                continue;
            }

            if (command.Length == 0)
            {
                continue;
            }

            ExecuteCommand(command, output);
        }
    }

    protected abstract void WriteHelp(TextWriter output);
    protected abstract void ExecuteCommand(string command, TextWriter output);

    protected static void Trace(TextWriter output, params string[] calls)
    {
        foreach (string call in calls)
        {
            output.WriteLine($"  -> {call}");
        }
    }
}
