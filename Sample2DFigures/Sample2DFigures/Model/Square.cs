using Sample2DFigures.Interfaces;

namespace Sample2DFigures.Model
{
    internal class Square : GeometryFigure, ISquare
    {
        public int Height { get; }

        public int Width { get; }

        public Square(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public static ISquare CreateInstance(int height, int width)
        {
            return new Square(height, width);
        }
    }
}
