using System.Linq;
using Sample2DFigures.Interfaces;
using System.Windows.Media;

namespace Sample2DFigures.ViewModels.FiguresVM
{
    internal sealed class TriangleViewModel : FigureBaseViewModel
    {
        private readonly ITriangle _figureModel;
        public TriangleViewModel(ITriangle figureModel)
        {
            _figureModel = figureModel;

            _points ??= new PointCollection(new[] { _figureModel.Point1, _figureModel.Point2, _figureModel.Point3/*, _figureModel.Point4*/ });

            PositionX = (int)_points.Min(point => point.X);
            PositionY = (int)_points.Min(point => point.Y);
        }

        private readonly PointCollection _points;
        public PointCollection TrianglePoints => _points;
    }
}
