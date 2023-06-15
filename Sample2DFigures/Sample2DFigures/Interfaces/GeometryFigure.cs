using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Sample2DFigures.Interfaces
{
    internal abstract class GeometryFigure : IFigure, INotifyPropertyChanged
    {
        private Brush _color;
        public Brush Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
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
