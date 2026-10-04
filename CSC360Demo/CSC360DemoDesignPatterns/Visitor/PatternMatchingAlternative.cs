namespace CSC360DemoDesignPatterns.Visitor;

public abstract record ShapeValue;
public sealed record CircleValue(double Radius) : ShapeValue;
public sealed record RectangleValue(double Width, double Height) : ShapeValue;

public static class PatternMatchingAlternative
{
    public static double Area(ShapeValue shape) => shape switch
    {
        CircleValue circle => Math.PI * circle.Radius * circle.Radius,
        RectangleValue rectangle => rectangle.Width * rectangle.Height,
        _ => throw new NotSupportedException($"Unsupported shape type: {shape.GetType().Name}.")
    };
}
