using Geometry2d.Contracts;

namespace Geometry2d.Shapes;

/// <summary>
/// Represents a circle shape on a two-dimensional plane.
/// </summary>
public sealed class Circle : Base2dShape
{
    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Initializes a new instance of the Circle class with the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle. Must be greater than zero.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the provided radius is less than or equal to zero.</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(radius),
                "Radius should be greater than zero."
            );

        Radius = radius;
    }

    /// <summary>
    /// Calculates and returns the area of the circle.
    /// </summary>
    /// <returns>The calculated area of the circle.</returns>
    /// <exception cref="OverflowException">Thrown if the calculated area is too large to be represented as a double.</exception>
    protected override double CalculateArea()
    {
        var area = Math.PI * Math.Pow(Radius, 2);

        if (area is double.PositiveInfinity)
            throw new OverflowException($"Area value is too large to fit in {typeof(double)}");

        return area;
    }
}