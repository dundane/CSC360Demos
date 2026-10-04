namespace CSC360DemoDesignPatterns.Command.UndoRedoDemo;

public sealed class UndoRedoHistory
{
    private readonly Stack<IUndoableCommand> undoCommands = new();
    private readonly Stack<IUndoableCommand> redoCommands = new();

    public void Execute(IUndoableCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        command.Execute();
        undoCommands.Push(command);
        redoCommands.Clear();
    }

    public bool Undo()
    {
        if (undoCommands.Count == 0)
        {
            return false;
        }

        IUndoableCommand command = undoCommands.Peek();
        command.Undo();
        undoCommands.Pop();
        redoCommands.Push(command);
        return true;
    }

    public bool Redo()
    {
        if (redoCommands.Count == 0)
        {
            return false;
        }

        IUndoableCommand command = redoCommands.Peek();
        command.Execute();
        redoCommands.Pop();
        undoCommands.Push(command);
        return true;
    }
}
