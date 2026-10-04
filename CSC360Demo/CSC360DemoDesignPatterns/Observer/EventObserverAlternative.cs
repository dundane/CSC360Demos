namespace CSC360DemoDesignPatterns.Observer;

public sealed class MessageEventArgs(string message) : EventArgs
{
    public string Message { get; } = message;
}

public sealed class EventObserverAlternative
{
    public event EventHandler<MessageEventArgs>? MessagePublished;

    public void Publish(string message) => MessagePublished?.Invoke(this, new MessageEventArgs(message));
}
