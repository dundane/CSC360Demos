using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Strategy {
    public interface IAIOpponent {
        void SetStrategy(IAIStrategy adjustedStrategy);
        void Attack();
    }
}
