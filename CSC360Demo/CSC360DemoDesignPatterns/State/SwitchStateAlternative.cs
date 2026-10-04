namespace CSC360DemoDesignPatterns.State;

public enum PlaybackState
{
    Stopped,
    Playing
}

public sealed class SwitchStateAlternative
{
    public PlaybackState State { get; private set; } = PlaybackState.Stopped;

    public PlaybackState Toggle() => State = State switch
    {
        PlaybackState.Stopped => PlaybackState.Playing,
        PlaybackState.Playing => PlaybackState.Stopped,
        _ => throw new InvalidOperationException($"Unknown playback state: {State}.")
    };
}
