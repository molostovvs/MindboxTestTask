namespace Geometry2d.Shapes.Tests;

public class CircleTests
{
    [TestCase(double.MinValue)]
    [TestCase(-1)]
    [TestCase(-1e-9)]
    [TestCase(0)]
    public void Circle_creation_with_invalid_radius_throws_ArgumentOutOfRange(double radius)
    {
        var circleCreation = () =>
        {
            _ = new Circle(radius);
        };

        circleCreation.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Area_when_equals_positive_infinity_throws_OverflowException()
    {
        const double radius = double.MaxValue;
        var circle = new Circle(radius);

        var areaCalling = () =>
        {
            _ = circle.Area;
        };

        areaCalling.Should().ThrowExactly<OverflowException>();
    }

    [TestCase(1e-4,       3.14159265e-8)]
    [TestCase(24e-4,      1.80955736847e-5)]
    [TestCase(5,          78.5398163397)]
    [TestCase(150.123456, 70802.23712678)]
    public void Area_should_be_valid_for_valid_radius(double radius, double expectedArea)
    {
        var circle = new Circle(radius);

        var area = circle.Area;

        area.Should().BeApproximately(expectedArea, 1e-6);
    }
}