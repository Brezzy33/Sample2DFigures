using Sample2DFigures.Interfaces;
using System.Windows;

namespace Sample2DFigures.Model
{
    internal class Triangle : GeometryFigure, ITriangle
    {
        public Point Point1 { get; }

        public Point Point2 { get; }

        public Point Point3 { get; }

        //To connect polygon
        public Point Point4 { get; }

        internal Triangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            Point4 = point1; 
        }

        public static Triangle CreateInstance(Point point1, Point point2, Point point3)
        {
            return new Triangle(point1, point2, point3);
        }
    }
}
