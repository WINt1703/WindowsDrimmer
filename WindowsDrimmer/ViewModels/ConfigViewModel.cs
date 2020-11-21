using System.Windows.Forms;
using System.Windows.Media;
using WindowsDimmer.Base;

namespace WindowsDimmer.ViewModels
{
    internal class ConfigViewModel : ViewModelBase
    {
        #region Fields
        private RelayCommand _setColorCommand;
        private Color _selectedColor;
        #endregion

        #region Propertys
        public Color SelectedColor 
        {
            get => _selectedColor;
            set => OnPropertyChanged(ref _selectedColor, value);
        }

        public RelayCommand SetColorCommand
        { 
            get
            {
                return _setColorCommand ?? (_setColorCommand = new RelayCommand(obj => 
                {
                    var controlOverlay = new ControlOverlayWindow(new Form(), ServiceManager.GetService<DrimmerViewModel>().SelectProcess);
                    controlOverlay.InitOverlayWindow(SelectedColor, 50);
                    controlOverlay.ShowOverlay();
                }));
            }
        }
        #endregion
    }
}
