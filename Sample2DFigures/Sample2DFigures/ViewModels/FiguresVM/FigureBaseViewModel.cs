using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample2DFigures.ViewModels.FiguresVM
{
    internal abstract class FigureBaseViewModel : INotifyPropertyChanged
    {
        //Required for listbox item board and selection on canvas
        private int _positionX;
        public int PositionX
        {
            get => _positionX;
            set
            {
                if (_positionX != value)
                {
                    _positionX = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _positionY;
        public int PositionY
        {
            get => _positionY;
            set
            {
                if (_positionY != value)
                {
                    _positionY = value;
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
