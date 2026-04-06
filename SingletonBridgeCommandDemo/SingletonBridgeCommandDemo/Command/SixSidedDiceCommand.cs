using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonBridgeCommandDemo.Command {
    internal class SixSidedDiceCommand : IDiceCommand {
        public void Execute() {
            throw new NotImplementedException();
        }
    }
}
