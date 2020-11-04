using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowsDrimmer.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        protected virtual void OnPropertyChanged<T>(ref T field, T value, [CallerMemberName] string property = "")
        {
            field = value;

            OnPropertyChanged(property);
        }
    }
}