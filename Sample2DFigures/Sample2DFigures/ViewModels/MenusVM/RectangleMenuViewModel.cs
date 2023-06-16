using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Sample2DFigures.Common;
using Sample2DFigures.Model;
using Sample2DFigures.ViewModels.FiguresVM;

namespace Sample2DFigures.ViewModels.MenusVM
{
    internal class RectangleMenuViewModel : INotifyPropertyChanged, IMenuModel
    {
        private readonly FiguresViewModel _figuresViewModel;
        public RectangleMenuViewModel(FiguresViewModel figuresViewModel)
        {
            _figuresViewModel = figuresViewModel;
        }

        private int _width = 40;
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

        private int _height = 40;
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

        private ICommand _addRectangleCommand;
        public ICommand AddFigureCommand => _addRectangleCommand ??= new RelayCommand(AddFigure);

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
            _figuresViewModel.FiguresCollection.Add(new RectangleViewModel(Rectangle.CreateInstance(Height, Width, StartPoint)));
        }
    }
}