using FluentAssertions;

namespace Geometry.Tests;

public class SegmentTests
{
    [Fact]
    public void A_segment_can_be_created_with_two_points()
    {
        var segment = new Segment(new Point(1.2,-5.6),
            new Point(-4.5, 6.7));

        segment.Start.X.Should().Be(1.2);
        segment.Start.Y.Should().Be(-5.6);
        segment.End.X.Should().Be(-4.5);
        segment.End.Y.Should().Be(6.7);
    }

    [Fact]
    public void A_segment_has_correct_length()
    {
        var segment = new Segment(new Point(0, 0), new Point(3, 4));

        segment.Length.Should().Be(5);
    }
}