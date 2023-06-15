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
