using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State;
public class FMRadio : IBoomBoxSource {
  public string PlayMuisc() {
    string url = @"https://open.spotify.com/track/0apB2QDN7ZrE91yDmw5JsY?si=e7d78e29af4a460f";

    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

    return "I've got the brains you've got the looks let's make lots of money...";
  }

  public string Source() {
    return "FM Radio";
  }
}
