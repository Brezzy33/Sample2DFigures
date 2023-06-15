using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sample2DFigures.Model;

namespace Sample2DFigures.ViewModels.MenusVM
{
    internal class SquareMenuViewModel : INotifyPropertyChanged, IMenuModel
    {
        private readonly FiguresViewModel _figuresViewModel;
        public SquareMenuViewModel(FiguresViewModel figuresViewModel)
        {
            _figuresViewModel = figuresViewModel;
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

        public void AddFigure()
        {
            _figuresViewModel.SquareCollection.Add(new SquareViewModel(Square.CreateInstance(Height, Width)));
        }

        public void RemoveFigure()
        {
            if (_figuresViewModel.SelectedFigureViewModel is SquareViewModel squareViewModel)
                _figuresViewModel.SquareCollection.Remove(squareViewModel);
        }
    }
}