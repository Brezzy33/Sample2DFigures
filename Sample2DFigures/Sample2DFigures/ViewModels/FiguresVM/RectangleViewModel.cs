using Sample2DFigures.Interfaces;

namespace Sample2DFigures.ViewModels.FiguresVM
{
    internal class RectangleViewModel : FigureBaseViewModel
    {
        private IRectangle _rectangle;
        public RectangleViewModel(IRectangle rectangle)
        {
            _rectangle = rectangle;
            Width = _rectangle.Width;
            Height = _rectangle.Height;

            PositionX = _rectangle.StartPoint.X;
            PositionY = _rectangle.StartPoint.Y;
        }

        private int _width;
        public int Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _height;
        public int Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged();
                }
            }
        }

        public string RectangleParameters => new($"{_rectangle.StartPoint.X},{_rectangle.StartPoint.Y}, {Width}, {Height}");
    }
}
