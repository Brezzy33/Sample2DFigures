using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Sample2DFigures.Common;
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

        private CustomPoint _startPoint = new(0,0);
        public CustomPoint StartPoint
        {
            get => _startPoint;
            set
            {
                if (_startPoint != value)
                {
                    _startPoint = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Command

        private ICommand _addSquareCommand;
        public ICommand AddFigureCommand => _addSquareCommand ??= new RelayCommand(AddFigure);

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void AddFigure()
        {
            _figuresViewModel.SquareCollection.Add(new SquareViewModel(Square.CreateInstance(Height, Width)));
        }
    }
}