using System.Drawing;

namespace TagsCloudVisualization.ManagingRendering;

public class ArchimedeanSpiral : ISpiral
{
    private readonly Point startPoint;
    private readonly double radiusStep;
    private readonly double angleStep;
    private double currentAngle;

    public ArchimedeanSpiral(Point startPoint, double radiusStep = 1)
    {
        if (radiusStep <= 0) throw new ArgumentOutOfRangeException(nameof(radiusStep), "radius step must be positive");

        angleStep = Math.PI / 180;
        this.startPoint = startPoint;
        this.radiusStep = radiusStep;
        currentAngle = 0;
    }

    public Point GetNextPoint()
    {
        var radius = radiusStep * currentAngle;

        var x = (int)(startPoint.X + radius * Math.Cos(currentAngle));
        var y = (int)(startPoint.Y + radius * Math.Sin(currentAngle));
        currentAngle += angleStep;

        return new Point(x, y);
    }
}