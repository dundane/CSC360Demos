using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC360DemoDesignPatterns.Command;
public interface ICharacter {
  public void Jump();
  public void Attack();
  public void Dash();
  public void Crouch();
}
