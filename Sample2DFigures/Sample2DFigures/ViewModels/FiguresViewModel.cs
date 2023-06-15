using System.Collections.Generic;
using Sample2DFigures.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Sample2DFigures.ViewModels.MenusVM;

namespace Sample2DFigures.ViewModels
{
    internal class FiguresViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, IMenuModel> _menus;

        #region Commands

        private ICommand _showSquareMenuCommand;
        public ICommand ShowSquareMenuCommand => _showSquareMenuCommand ??= new RelayCommand(() => SelectedMenuModel = _menus[1]);

        private ICommand _showTriangleMenuCommand;
        public ICommand ShowTriangleMenuCommand => _showTriangleMenuCommand ??= new RelayCommand(() => SelectedMenuModel = _menus[0]);

        #endregion

        public FiguresViewModel()
        {
            TriangleCollection = new ObservableCollection<TriangleViewModel?>();
            SquareCollection = new ObservableCollection<SquareViewModel>();

            _menus = new Dictionary<int, IMenuModel>
            {
                {0, new TriangleMenuViewModel(this)},
                {1, new SquareMenuViewModel(this)}
            };
        }

        public ObservableCollection<TriangleViewModel?> TriangleCollection { get; set; }

        public ObservableCollection<SquareViewModel> SquareCollection { get; set; }

        private IFigureViewModel _selectedFigureViewModel;
        public IFigureViewModel SelectedFigureViewModel
        {
            get => _selectedFigureViewModel;
            set
            {
                if (_selectedFigureViewModel != value)
                {
                    _selectedFigureViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        private IMenuModel _selectedMenuModel;
        public IMenuModel SelectedMenuModel
        {
            get => _selectedMenuModel;
            set
            {
                if (value != _selectedMenuModel)
                {
                    _selectedMenuModel = value;
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
