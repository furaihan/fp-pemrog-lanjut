using PinusPengger.Model.ServiceAgent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayReservationsVM : ViewModelBase
    {
        public DisplayReservationsVM()
        {
            _searchCommand = new ViewModelCommand(param => GetData());
            _reservationSA = new ReservationSA();
            ReservationJoineds = new ObservableCollection<ReservationJoined>();
        }

        #region Field
        private string _target = string.Empty;
        private ICommand _searchCommand;
        private ReservationSA _reservationSA;
        #endregion

        #region Properties
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
                _searchCommand ??= new ViewModelCommand(param => GetData());
                return _searchCommand;
            }
        }
        public ObservableCollection<ReservationJoined> ReservationJoineds { get; set; }
        #endregion

        #region Method
        public void GetData()
        {
            _reservationSA.FetchData();
            var data = _reservationSA.GetData(_target);
            ReservationJoineds = new ObservableCollection<ReservationJoined>(data as IEnumerable<ReservationJoined> ?? Enumerable.Empty<ReservationJoined>());
        }
        #endregion
    }
}
