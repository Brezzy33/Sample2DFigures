using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample2DFigures.Common
{
    internal class CustomPoint : INotifyPropertyChanged
    {
        public CustomPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        private int _x;
        public int X
        {
            get => _x;
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _y;
        public int Y
        {
            get => _y;
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return string.Format($"{X}:{Y}");
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
