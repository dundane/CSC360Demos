using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Facade {
    public class SpotifyFacade : ISpotifyFacade {
        public void KillSpotify() {
            // Create a query to find the Spotify process
            string query = "SELECT * FROM Win32_Process WHERE Name='Spotify.exe'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            // Execute the query and close each process
            foreach (ManagementObject obj in searcher.Get()) {
                uint processId = (uint)obj["ProcessId"];
                Process process = Process.GetProcessById((int)processId);
                process.Kill();
            }
            Thread.Sleep(2000);
        }

        public void PlaySpotify(string songPath) {
            Process.Start(new ProcessStartInfo(songPath) { UseShellExecute = true });
        }
    }
}
