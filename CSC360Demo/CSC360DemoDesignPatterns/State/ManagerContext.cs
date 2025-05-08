using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.State {
    public class ManagerContext {
        IContext child;
        public  ManagerContext(IContext contextChild) { 
            child = contextChild;
        }
    }
}
