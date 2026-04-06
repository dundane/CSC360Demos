using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Facade {

    public class DemoFacade : IDemoFacade {
        public Lazy<ISpotifyFacade> SpotifyFacade {
            get { return new Lazy<ISpotifyFacade>(() => new SpotifyFacade()); }
        }
    }
}
