using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State;
public class AMRadio : IBoomBoxSource {
  public string PlayMuisc() {
    string url = @"https://open.spotify.com/track/6hGMlZMkzZ2pvKB0P9UDaf?si=e1f2f2182a5d404a";

    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

    return "Rock and rock and roll radio...Let's go.";
  }

  public string Source() {
    return "AM Radio";
  }
}
