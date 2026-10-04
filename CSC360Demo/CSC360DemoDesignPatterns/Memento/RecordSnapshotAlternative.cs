namespace CSC360DemoDesignPatterns.Memento;

public sealed record EditorSnapshot(string Text);

public sealed class RecordSnapshotAlternative
{
    public string Text { get; private set; } = string.Empty;

    public void Write(string text) => Text += text;
    public EditorSnapshot Save() => new(Text);
    public void Restore(EditorSnapshot snapshot) => Text = snapshot.Text;
}
