namespace Geometry2d.Contracts;

/// <summary>
/// This abstract class provides the foundation for representing two-dimensional shapes.
/// </summary>
public abstract class Base2dShape
{
    private double _cachedArea;

    /// <summary>
    /// Gets the calculated area of the shape.
    /// 
    /// This property utilizes a caching mechanism to improve performance. The first time
    /// `Area` is accessed, the `CalculateArea` method is called to compute the area.
    /// This value is then stored internally for subsequent calls.
    /// </summary>
    public double Area
    {
        get
        {
            if (_cachedArea == 0)
                _cachedArea = CalculateArea();

            return _cachedArea;
        }
    }

    /// <summary>
    /// Subclasses inheriting from Base2dShape must implement this abstract method
    /// to define the specific logic for calculating their own area.
    /// 
    /// Since this method is abstract, it has no implementation provided in this base class.
    /// </summary>
    /// <returns>The calculated area of the specific shape.</returns>
    protected abstract double CalculateArea();
}