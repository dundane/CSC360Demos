namespace CSC360DemoDesignPatterns.Visitor;

public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Rectangle rectangle);
}

public interface IShapeElement
{
    void Accept(IShapeVisitor visitor);
}

public sealed class Circle(double radius) : IShapeElement
{
    public double Radius { get; } = radius;
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

public sealed class Rectangle(double width, double height) : IShapeElement
{
    public double Width { get; } = width;
    public double Height { get; } = height;
    public void Accept(IShapeVisitor visitor) => visitor.Visit(this);
}

public sealed class AreaVisitor : IShapeVisitor
{
    public double TotalArea { get; private set; }

    public void Visit(Circle circle) => TotalArea += Math.PI * circle.Radius * circle.Radius;
    public void Visit(Rectangle rectangle) => TotalArea += rectangle.Width * rectangle.Height;
}
