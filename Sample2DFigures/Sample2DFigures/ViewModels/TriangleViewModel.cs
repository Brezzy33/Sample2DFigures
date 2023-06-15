using Sample2DFigures.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Sample2DFigures.ViewModels
{
    internal sealed class TriangleViewModel : IFigureViewModel, INotifyPropertyChanged
    {
        private readonly ITriangle _figureModel;
        public TriangleViewModel(ITriangle figureModel)
        {
            _figureModel = figureModel;
            OnPropertyChanged("TrianglePoints");
        }

        private PointCollection _points;
        public PointCollection TrianglePoints
        {
            get
            {
                _points ??= new PointCollection(new[] { _figureModel.Point1, _figureModel.Point2, _figureModel.Point3/*, _figureModel.Point4*/ });
                return _points;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
