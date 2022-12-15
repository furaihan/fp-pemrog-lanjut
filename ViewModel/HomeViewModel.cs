using PinusPengger.Model;
using PinusPengger.Repository;
using PinusPengger.ViewModel.Extension;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        // KITA JOINAN DI SINI
        public HomeViewModel()
        {
            _reservationRepo = new ReservationCRUD();
            _customerRepo = new CustomerCRUD();
            _roomRepo = new RoomCRUD();
            _reservationList = new List<Reservation>();
            _customerList = new List<Customer>();
            _roomList = new List<Room>();
            FetchData();
            GetData();
        }

        #region Field
        private string _target;
        private ICommand _searchCommand;
        private ReservationCRUD _reservationRepo;
        private CustomerCRUD _customerRepo;
        private RoomCRUD _roomRepo;
        private List<Reservation> _reservationList;
        private List<Customer> _customerList;
        private List<Room> _roomList;
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
                if (_searchCommand == null)
                {
                    _searchCommand = new ViewModelCommand(GetData);
                }
                return _searchCommand;
            }
        }
        public ObservableCollection<ReservationJoined> Source { get; set; }
        #endregion

        #region Method
        private void FetchData()
        {
            _reservationList.Clear();
            _customerList.Clear();
            _roomList.Clear();
            _reservationRepo.ReadData().ForEach(data => _reservationList.Add(data));
            _customerRepo.ReadData().ForEach(data => _customerList.Add(data));
            _roomRepo.ReadData().ForEach(data => _roomList.Add(data));
        }
        public void GetData(object target = null)
        {
            var data = from reservation in _reservationList
                       join customer in _customerList on reservation.ResIDCust equals customer.CustID
                       join room in _roomList on reservation.ResIDRoom equals room.RoomID
                       select new ReservationJoined
                       {
                           ReservationEntity = reservation,
                           CustomerEntity = customer,
                           RoomEntity = room
                       };
            if (string.IsNullOrEmpty(target.ToString()))
            {
                Source = null;
                Source = new ObservableCollection<ReservationJoined>(data);
            }
            else
            {
                Source = null;
                Source = new ObservableCollection<ReservationJoined>(
                    from x in data
                    where x.ReservationEntity.ResCode == target.ToString()
                    select x);
            }
        }
        #endregion
    }
}