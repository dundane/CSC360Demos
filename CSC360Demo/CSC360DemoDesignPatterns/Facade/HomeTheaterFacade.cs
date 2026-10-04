namespace CSC360DemoDesignPatterns.Facade;

public sealed class Projector
{
    public string TurnOn() => "Projector on";
}

public sealed class AudioSystem
{
    public string Configure() => "Audio configured";
}

public sealed class MoviePlayer
{
    public string Play(string title) => $"playing '{title}'";
}

public sealed class HomeTheaterFacade
{
    private readonly Projector projector = new();
    private readonly AudioSystem audio = new();
    private readonly MoviePlayer player = new();

    public string WatchMovie(string title)
    {
        return $"{projector.TurnOn()}; {audio.Configure()}; {player.Play(title)}.";
    }
}
