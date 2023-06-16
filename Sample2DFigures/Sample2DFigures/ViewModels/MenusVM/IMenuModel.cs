using System.Windows.Input;

namespace Sample2DFigures.ViewModels.MenusVM
{
    internal interface IMenuModel
    {
        public ICommand AddFigureCommand { get; }
    }
}
