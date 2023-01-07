using System;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// ViewModel untuk halaman home
    /// </summary>
    internal class HomeViewModel : ViewModelBase
    {
        /// <summary>
        /// Menginisialisasi instance sekaligus mengambil data dari database
        /// </summary>
        public HomeViewModel()
        {
        }

        #region Field
        private string _target = "a";
        private ICommand _searchCommand;
        private ICommand _checkinCommand;
        private ICommand _cancelCommand;
        private ICommand _checkoutCommand;
        #endregion

        #region Properties
        public string ErrorMessage { get; set; }
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
        public ICommand CheckinCommand
        {
            get
            {
                _checkinCommand ??= new ViewModelCommand(param => Checkin());
                return _checkinCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                _cancelCommand ??= new ViewModelCommand(param => Cancel());
                return _cancelCommand;
            }
        }
        public ICommand CheckoutCommand
        {
            get
            {
                _checkoutCommand ??= new ViewModelCommand(param => Checkout());
                return _checkoutCommand;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Memperbarui status item terpilih menjadi checkin
        /// </summary>
        public void Checkin()
        {
            
        }
        /// <summary>
        /// Menghapus item dari tabel reservasi
        /// </summary>
        public void Cancel()
        {
            
        }
        /// <summary>
        /// Menghapus item dari tabel reservasi sekaligus memasukkan item ke tabel riwayat
        /// </summary>
        public void Checkout()
        {
            
        }
        #endregion
    }
}