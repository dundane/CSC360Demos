namespace CSC360DemoDesignPatterns.Adapter;

public sealed record RoundPegValue(double Radius);

public sealed record SquarePegValue(double Width)
{
    public static explicit operator RoundPegValue(SquarePegValue peg)
    {
        ArgumentNullException.ThrowIfNull(peg);
        return new RoundPegValue(peg.Width * Math.Sqrt(2) / 2);
    }
}
