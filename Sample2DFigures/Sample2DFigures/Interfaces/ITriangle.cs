using System.Windows;

namespace Sample2DFigures.Interfaces
{
    internal interface ITriangle
    {
        Point Point1 { get; }

        Point Point2 { get; }

        Point Point3 { get; }

        //To connect polygon
        Point Point4 { get; }
    }
}
