using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Strategy {
    public class AIOpponent : IAIOpponent {
        private IAIStrategy strategy;
        public AIOpponent(IAIStrategy startingStrategy) {
            strategy = startingStrategy;
        }
        public void SetStrategy(IAIStrategy adjustedStrategy) {
            strategy = adjustedStrategy;
        }
        public void Attack() { 
            strategy.Attack();
        }
    }
}
