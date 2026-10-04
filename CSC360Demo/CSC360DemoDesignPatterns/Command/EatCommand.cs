using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Command {
    public class EatCommand : ICommandInterface {
        private ICharacter _character;

        public EatCommand(ICharacter character) {
            _character = character;
        }

        public void Execute() {
            _character.Eat();
        }
    }
}
