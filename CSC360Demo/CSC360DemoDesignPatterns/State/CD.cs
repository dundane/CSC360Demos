using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State;
public class CD : IBoomBoxSource {
  public string PlayMuisc() {
    
    string url = @"https://open.spotify.com/track/2RKDbMwtJgKc76H9oPo7Cl?si=5db281df2a494f3d";

    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

    return "I would say I'm sorry if I thought that it would change your mind.";
  }

  public string Source() {
    return "CD Player";
  }
}
