namespace CSC360DemoDesignPatterns.Memento;

public sealed class TextEditor
{
    public string Text { get; private set; } = string.Empty;

    public void Write(string text) => Text += text;

    public TextEditorMemento Save() => new(Text);

    public void Restore(TextEditorMemento memento) => Text = memento.Text;
}

public sealed class TextEditorMemento
{
    internal TextEditorMemento(string text) => Text = text;

    internal string Text { get; }
}
