using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State;
public class Player45 : IBoomBoxSource {
  public string PlayMuisc() {
    string url = @"https://open.spotify.com/track/07q0QVgO56EorrSGHC48y3?si=65f1afacf48a40b4";

    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

    return "I was made for lovin you baby.....";
  }

  public string Source() {
    return "45 Record";
  }
}
