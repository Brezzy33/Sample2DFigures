using Sample2DFigures.ViewModels;
using Sample2DFigures.ViewModels.FiguresVM;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Sample2DFigures.View
{
    /// <summary>
    /// Interaction logic for FiguresView.xaml
    /// </summary>
    public partial class FiguresView
    {
        public FiguresView()
        {
            InitializeComponent();
        }

        private void SelectedFigure_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (sender)
            {
                case Polygon polygon:
                    (DataContext as FiguresViewModel)!.SelectedFigureViewModel = (TriangleViewModel)polygon.DataContext;
                    break;
                case Path rectangle:
                    (DataContext as FiguresViewModel)!.SelectedFigureViewModel = (RectangleViewModel)rectangle.DataContext;
                    break;
                case null:
                    break;
            }
        }

        private void EventSetter_OnHandler(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
