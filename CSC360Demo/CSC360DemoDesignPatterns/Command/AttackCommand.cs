using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Command;
public class AttackCommand : ICommandInterface{

  private ICharacter character;
  public AttackCommand(ICharacter character) {
    this.character = character;
  }
  public void Execute() {
    character.Attack();
  }
}
