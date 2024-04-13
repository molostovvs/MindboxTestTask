using Geometry2d.Contracts;

namespace Geometry2d.Shapes;

/// <summary>
/// Represents a triangle shape on a two-dimensional plane.
/// </summary>
public sealed class Triangle : Base2dShape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    /// <summary>
    /// A value indicating whether this triangle is a right triangle.
    /// </summary>
    public bool IsRight => Math.Abs(Math.Pow(A, 2) - (Math.Pow(B, 2) + Math.Pow(C, 2))) < 1e-6;

    /// <summary>
    /// Initializes a new instance of the Triangle class with the specified side lengths.
    /// </summary>
    /// <param name="side1">The length of the first side.</param>
    /// <param name="side2">The length of the second side.</param>
    /// <param name="side3">The length of the third side.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if any of the provided side lengths are less than or equal to zero.</exception>
    public Triangle(double side1, double side2, double side3)
    {
        CheckSides(ref side1, ref side2, ref side3);

        //sort sides to use numerical stable Herons formula
        //use builtin sorting since we have only 3 values
        var orderedSides = new[] { side1, side2, side3 }.OrderDescending().ToArray();

        A = orderedSides[0];
        B = orderedSides[1];
        C = orderedSides[2];
    }

    private static void CheckSides(ref double a, ref double b, ref double c)
    {
        CheckSide(ref a);
        CheckSide(ref b);
        CheckSide(ref c);
    }

    private static void CheckSide(ref double side)
    {
        if (side <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(side),
                $"The side {nameof(side)} should be greater than zero."
            );
    }

    protected override double CalculateArea()
    {
        var p1 = A + (B + C);
        var p2 = C - (A - B);
        var p3 = C + (A - B);
        var p4 = A + (B - C);

        //Numerical stable Herons formula https://en.wikipedia.org/wiki/Heron%27s_formula
        var area = (double)1 / 4 * Math.Sqrt(p1 * p2 * p3 * p4);

        if (area is double.PositiveInfinity)
            throw new OverflowException($"Area value is too large to fit in {typeof(double)}");

        return area;
    }
}