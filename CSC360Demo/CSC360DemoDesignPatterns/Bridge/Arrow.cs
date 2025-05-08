namespace CSC360DemoDesignPatterns.Bridge;
public class Arrow : IShape {
  private IColor color;
  public Arrow(IColor color) {
    this.color = color;
  }
  public void Draw() {
    Console.WriteLine($"Arrow drawn in {color.ApplyColor()} color.");
  }
}
