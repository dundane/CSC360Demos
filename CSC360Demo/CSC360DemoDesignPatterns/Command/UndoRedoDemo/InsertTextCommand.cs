namespace CSC360DemoDesignPatterns.Command.UndoRedoDemo;

public sealed class InsertTextCommand(TextDocument document, int index, string text) : IUndoableCommand
{
    private bool isApplied;

    public void Execute()
    {
        if (isApplied)
        {
            throw new InvalidOperationException("The command is already applied.");
        }

        document.Insert(index, text);
        isApplied = true;
    }

    public void Undo()
    {
        if (!isApplied)
        {
            throw new InvalidOperationException("The command has not been applied.");
        }

        document.Remove(index, text.Length);
        isApplied = false;
    }
}
