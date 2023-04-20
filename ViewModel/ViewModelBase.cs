using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// The ViewModelBase class is a base class for all ViewModel classes.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        ///<summary>
        /// Invokes the PropertyChanged event to indicate that a property value has changed.
        ///</summary>
        ///<param name="name">The name of the property that has changed. (optional)</param>
        ///<remarks>
        /// This method is called internally to notify the view that the property value has changed.
        ///</remarks>
        ///<seealso cref="System.ComponentModel.INotifyPropertyChanged.PropertyChanged"/>
        ///<seealso cref="System.Runtime.CompilerServices.CallerMemberNameAttribute"/>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            //Debug.WriteLine($"PropertyChanged Invoke --> Member Name:{name}");
        }
    }
}
