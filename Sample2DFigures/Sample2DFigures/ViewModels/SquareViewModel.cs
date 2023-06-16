using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sample2DFigures.Interfaces;

namespace Sample2DFigures.ViewModels
{
    internal class SquareViewModel : IFigureViewModel, INotifyPropertyChanged
    {
        private ISquare _square;
        public SquareViewModel(ISquare square)
        {
            _square = square;
            Width = _square.Width;
            Height = _square.Height;
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

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
