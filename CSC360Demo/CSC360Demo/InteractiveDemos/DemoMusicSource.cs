using CSC360DemoDesignPatterns.State;

namespace CSC360Demo.InteractiveDemos;

public sealed class DemoMusicSource : IInteractiveBoomBoxSource
{
    public DemoMusicSource()
    {
    }

    public string PlayMuisc() => "Demo track";
    public string Source() => "Demo Music";
}
