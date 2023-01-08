using PinusPengger.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// View model untuk halaman riwayat
    /// </summary>
    class HistoryViewModel : ViewModelBase
    {
        /// <summary>
        /// Menginisialisasi instance sekaligus mengambil data dari database
        /// </summary>
        public HistoryViewModel()
        {
            
        }

        #region Field
        private string _target = string.Empty;
        private ICommand _searchCommand;
        #endregion

        #region Properties
        public string MessageError { get; set; }
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(null);
                return _searchCommand;
            }
        }
        #endregion

        #region Method
        
        #endregion
    }
}
