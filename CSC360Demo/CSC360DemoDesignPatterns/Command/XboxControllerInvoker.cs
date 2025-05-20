namespace CSC360DemoDesignPatterns.Command;
public class XboxControllerInvoker {
  public Dictionary<string, ICommandInterface> commands;

  public XboxControllerInvoker() { 
    commands = new Dictionary<string, ICommandInterface>();
  }

  public void SetCommand(string button, ICommandInterface command) {
    if (!commands.ContainsKey(button)) {
      commands.Add(button, command);
    } else {
      commands[button] = command;
    }
  }
  public void PressButton(string button) {
    if (commands.ContainsKey(button)) {
      commands[button].Execute();
    } else {
      Console.WriteLine("Invalid Command");
    }
  }

}
