using MyFacade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeFinal {
    public static class FacadeSingleton {
        private static IFacade facade;
        public static IFacade Instance {
            get {
                if (facade == null) {
                    facade = new Facade();
                }
                return facade;
            }
        }
    }
}
