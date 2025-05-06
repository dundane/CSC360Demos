using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State;
public class MP3Player : IBoomBoxSource {
  public string PlayMuisc() {
    string url = @"https://open.spotify.com/track/3ccAZx3wLZDVB2Nq6rikf9?si=02e13425667d4c14";

    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

    return "Call me morbid";
  }

  public string Source() {
    return "MP3 Player";
  }
}
