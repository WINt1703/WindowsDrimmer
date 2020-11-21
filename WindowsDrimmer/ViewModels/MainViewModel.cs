using System.Collections.ObjectModel;
using WindowsDimmer.Base;

namespace WindowsDimmer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ObservableCollection<object> _views;
        private object _selectedView;

        public ObservableCollection<object> Views
        {
            get => _views;
            set => OnPropertyChanged(ref _views, value);
        }

        public object SelectedView
        {
            get => _selectedView;
            set => OnPropertyChanged(ref _selectedView, value);
        }

        public MainViewModel()
        {
            ServiceManager.GetService(() => this);

            Views = new ObservableCollection<object>
            {
                ServiceManager.GetService(() => new DrimmerViewModel()),
                ServiceManager.GetService(() => new ConfigViewModel()),
            };

            SelectedView = Views[0];
        }
    }
}
