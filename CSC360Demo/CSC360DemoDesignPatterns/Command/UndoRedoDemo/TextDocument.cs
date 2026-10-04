namespace CSC360DemoDesignPatterns.Command.UndoRedoDemo;

public sealed class TextDocument
{
    public string Text { get; private set; } = string.Empty;

    public void Insert(int index, string text)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentNullException.ThrowIfNull(text);
        if (index > Text.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Text = Text.Insert(index, text);
    }

    public string Remove(int index, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfNegative(length);
        if (index > Text.Length || length > Text.Length - index)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        string removedText = Text.Substring(index, length);
        Text = Text.Remove(index, length);
        return removedText;
    }
}
