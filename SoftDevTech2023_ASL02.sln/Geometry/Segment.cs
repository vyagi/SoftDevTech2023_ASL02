namespace Geometry;

public class Segment
{
    public Point Start { get; }
    public Point End { get; }

    public double Length => Math.Sqrt(Math.Pow(Start.X - End.X, 2) +
                                      Math.Pow(Start.Y - End.Y, 2));

    public Segment(Point point, Point point1)
    {
        Start = point;
        End = point1;
    }
}