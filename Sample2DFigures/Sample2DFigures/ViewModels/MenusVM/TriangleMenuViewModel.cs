using Sample2DFigures.Common;
using Sample2DFigures.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Sample2DFigures.ViewModels.MenusVM
{
    internal class TriangleMenuViewModel : IMenuModel, INotifyPropertyChanged
    {
        private readonly FiguresViewModel _figuresViewModel;
        public TriangleMenuViewModel(FiguresViewModel figuresViewModel)
        {
            _figuresViewModel = figuresViewModel;
        }

        private CustomPoint _point1 = new(300,200);
        public CustomPoint Point1
        {
            get => _point1;
            set
            {
                if (_point1 != value)
                {
                    _point1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private CustomPoint _point2 = new(400, 125);
        public CustomPoint Point2
        {
            get => _point2;
            set
            {
                if (_point2 != value)
                {
                    _point2 = value;
                    OnPropertyChanged();
                }
            }
        }

        private CustomPoint _point3 = new(400, 275);
        public CustomPoint Point3
        {
            get => _point3;
            set
            {
                if (_point3 != value)
                {
                    _point3 = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Commands

        private ICommand _addTriangleCommand;
        public ICommand AddFigureCommand => _addTriangleCommand ??= new RelayCommand(AddFigure);

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
            _figuresViewModel.TriangleCollection.Add(new TriangleViewModel(
                Triangle.CreateInstance(
                    new Point(Point1.X, Point1.Y),
                    new Point(Point2.X, Point2.Y), 
                    new Point(Point3.X, Point3.Y)
                    )));
        }
    }
}
