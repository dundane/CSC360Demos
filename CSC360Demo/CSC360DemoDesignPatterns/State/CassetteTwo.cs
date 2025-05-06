using System.Diagnostics;

namespace CSC360DemoDesignPatterns.State;
public class CassetteTwo : IBoomBoxSource {
  public string PlayMuisc() {

    string url = "https://open.spotify.com/track/4cgjA7B4fJBHyB9Ya2bu0t?si=3a9d45f87adf4486";
    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    return "Looking out...";
  }

  public string Source() {
    return "Audio Cassette Two";
  }
}
