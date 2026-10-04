namespace CSC360DemoDesignPatterns.Command.UndoRedoDemo;

public sealed class DeleteTextCommand(TextDocument document, int index, int length) : IUndoableCommand
{
    private string? deletedText;

    public void Execute()
    {
        if (deletedText is not null)
        {
            throw new InvalidOperationException("The command is already applied.");
        }

        deletedText = document.Remove(index, length);
    }

    public void Undo()
    {
        if (deletedText is null)
        {
            throw new InvalidOperationException("The command has not been applied.");
        }

        document.Insert(index, deletedText);
        deletedText = null;
    }
}
