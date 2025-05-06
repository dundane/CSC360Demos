namespace CSC360DemoDesignPatterns.Bridge;
public class Square : IShape {
  private IColor color;
  public Square(IColor color) {
    this.color = color;
  }
  public void Draw() {
    Console.WriteLine($"Square drawn in {color.ApplyColor()} color.");
  }
}
