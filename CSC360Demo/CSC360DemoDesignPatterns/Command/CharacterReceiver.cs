using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Command;
public class CharacterReceiver : ICharacter {

  public void Jump() {
    Console.WriteLine("Jump");
  }
  public void Attack() {
    Console.WriteLine("Attack");
  }
  public void Dash() {
    Console.WriteLine("Dash");
  }
  public void Crouch() {
    Console.WriteLine("Crouch");
  }
}
