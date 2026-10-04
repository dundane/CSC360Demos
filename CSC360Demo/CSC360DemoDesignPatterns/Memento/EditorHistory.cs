namespace CSC360DemoDesignPatterns.Memento;

public sealed class EditorHistory
{
    private readonly Stack<TextEditorMemento> states = new();

    public void Save(TextEditor editor) => states.Push(editor.Save());

    public bool Undo(TextEditor editor)
    {
        if (!states.TryPop(out TextEditorMemento? memento))
        {
            return false;
        }

        editor.Restore(memento);
        return true;
    }
}
