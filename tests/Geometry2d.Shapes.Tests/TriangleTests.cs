namespace Geometry2d.Shapes.Tests;

public class TriangleTests
{
    [TestCase(0, 1, 1)]
    [TestCase(1, 0, 1)]
    [TestCase(1, 1, 0)]
    public void Triangle_creation_with_invalid_side_throws_ArgumentOutOfRange(double a, double b,
        double c)
    {
        var triangleCreation = () =>
        {
            _ = new Triangle(a, b, c);
        };

        triangleCreation.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Test]
    public void Area_when_equals_positive_infinity_throws_OverflowException()
    {
        var triangle = new Triangle(double.MaxValue, double.MaxValue, double.MaxValue);

        var callingArea = () =>
        {
            _ = triangle.Area;
        };

        callingArea.Should().ThrowExactly<OverflowException>();
    }

    [TestCase(10, 9,  8)]
    [TestCase(9,  10, 8)]
    [TestCase(8,  9,  10)]
    public void Side_A_is_always_biggest(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        var aIsBiggerThanB = triangle.A > triangle.B;
        var aIsBiggerThanC = triangle.A > triangle.C;

        aIsBiggerThanB.Should().BeTrue();
        aIsBiggerThanC.Should().BeTrue();
    }

    [TestCase(10, 9,  8)]
    [TestCase(8,  10, 9)]
    [TestCase(8,  9,  10)]
    public void Side_C_is_always_smallest(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        var cIsSmallerThanA = triangle.C < triangle.A;
        var cIsSmallerThanB = triangle.C < triangle.B;

        cIsSmallerThanA.Should().BeTrue();
        cIsSmallerThanB.Should().BeTrue();
    }

    [TestCase(3,  4,  5,  6)]
    [TestCase(8,  9,  10, 34.197039)]
    [TestCase(12, 13, 10, 56.995066)]
    public void Area_is_valid(double a, double b, double c, double expectedArea)
    {
        var triangle = new Triangle(a, b, c);

        triangle.Area.Should().BeApproximately(expectedArea, 1e-6);
    }

    [TestCase(3, 4, 5)]
    [TestCase(5, 6, 7.81024967591)]
    public void Right_triangle_is_right(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        triangle.IsRight.Should().BeTrue();
    }

    [TestCase(1, 2, 3)]
    [TestCase(4, 5, 6)]
    public void Not_right_triangle_is_not_right(double a, double b, double c)
    {
        var triangle = new Triangle(a, b, c);

        triangle.IsRight.Should().BeFalse();
    }
}