using System.Collections.Generic;
using Sample2DFigures.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Sample2DFigures.ViewModels.MenusVM;
using Sample2DFigures.ViewModels.FiguresVM;

namespace Sample2DFigures.ViewModels
{
    internal class FiguresViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<int, IMenuModel> _menus;

        #region Commands

        private ICommand _showRectangleMenuCommand;
        public ICommand ShowRectangleMenuCommand => _showRectangleMenuCommand ??= new RelayCommand(() => SelectedMenuModel = _menus[1]);

        private ICommand _showTriangleMenuCommand;
        public ICommand ShowTriangleMenuCommand => _showTriangleMenuCommand ??= new RelayCommand(() => SelectedMenuModel = _menus[0]);

        public ICommand AddFigureCommand => SelectedMenuModel.AddFigureCommand;

        private ICommand _removeFigureCommand;
        public ICommand RemoveFigureCommand => _removeFigureCommand ??= new RelayCommand(RemoveFigure);

        #endregion

        public FiguresViewModel()
        {
            FiguresCollection = new ObservableCollection<FigureBaseViewModel?>();

            _menus = new Dictionary<int, IMenuModel>
            {
                {0, new TriangleMenuViewModel(this)},
                {1, new RectangleMenuViewModel(this)}
            };
            SelectedMenuModel = _menus[0];
        }

        public ObservableCollection<FigureBaseViewModel?> FiguresCollection { get; set; }

        private FigureBaseViewModel _selectedFigureViewModel;
        public FigureBaseViewModel SelectedFigureViewModel
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
                    OnPropertyChanged("AddFigureCommand");
                }
            }
        }

        private void RemoveFigure()
        {
            switch (SelectedFigureViewModel)
            {
                case TriangleViewModel:
                    FiguresCollection.Remove((TriangleViewModel?)SelectedFigureViewModel);
                    break;
                case RectangleViewModel:
                    FiguresCollection.Remove((RectangleViewModel)SelectedFigureViewModel);
                    break;
                case null:
                    break;
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
