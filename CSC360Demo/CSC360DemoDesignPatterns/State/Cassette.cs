using System.Diagnostics;

namespace CSC360DemoDesignPatterns.State;
public class Cassette : IBoomBoxSource {
  public string PlayMuisc() {

    string url = "https://open.spotify.com/track/1wyVyr8OhYsC9l0WgPPbh8?si=4ebdb959aba34689";
    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    return "Bella Lugosi's Dead...Undead.Undead.Undead";
  }

  public string Source() {
    return "Audio Cassette";
  }
}
