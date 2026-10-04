namespace CSC360DemoDesignPatterns.Command.UndoRedoDemo;

public interface IUndoableCommand
{
    void Execute();
    void Undo();
}
