using FluentAssertions;

namespace Geometry.Tests;

public class PointTests
{
    [Fact]
    public void A_point_can_be_created_without_arguments()
    {
        var point = new Point();

        point.X.Should().Be(0);
        point.Y.Should().Be(0);
    }

    [Fact]
    public void A_point_can_be_created_with_one_argument()
    {
        var point = new Point(5);

        point.X.Should().Be(5);
        point.Y.Should().Be(5);
    }

    [Fact]
    public void A_point_can_be_created_with_two_arguments()
    {
        var point = new Point(-4.5, 5.6);

        point.X.Should().Be(-4.5);
        point.Y.Should().Be(5.6);
    }

    [Fact]
    public void A_point_can_be_moved()
    {
        var point = new Point(4, 7);

        point.Move(-2.5, 3.3);
        point.X.Should().Be(1.5);
        point.Y.Should().Be(10.3);
        point.Should().BeAssignableTo<IMoveable>();
    }

    [Fact]
    public void A_point_has_correct_distance()
    {
        var point = new Point(3, 4);

        point.Distance.Should().Be(5);
    }
}