using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Facade {
    public interface ISpotifyFacade{
        public void KillSpotify();
        public void PlaySpotify(string songPath);

    }
}
