using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PinusPengger.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            //Debug.WriteLine($"PropertyChanged Invoke --> Member Name:{name}");
        }
    }
}
