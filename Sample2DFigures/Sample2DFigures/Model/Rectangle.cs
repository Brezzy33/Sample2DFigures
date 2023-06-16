using Sample2DFigures.Common;
using Sample2DFigures.Interfaces;

namespace Sample2DFigures.Model
{
    internal class Rectangle : BaseGeometryFigure, IRectangle
    {
        public int Height { get; }

        public int Width { get; }

        public CustomPoint StartPoint { get; }

        public Rectangle(int height, int width, CustomPoint startPoint)
        {
            Height = height;
            Width = width;
            StartPoint = startPoint;
        }

        public static IRectangle CreateInstance(int height, int width, CustomPoint startPoint)
        {
            return new Rectangle(height, width, startPoint);
        }
    }
}
