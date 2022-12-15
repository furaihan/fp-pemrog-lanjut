using PinusPengger.Model;
using PinusPengger.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            _reservationRepo = new ReservationCRUD();
            _customerRepo = new CustomerCRUD();
            _roomRepo = new RoomCRUD();
            _historyRepo = new HistoryCRUD();
            _reservationList = new List<Reservation>();
            _customerList = new List<Customer>();
            _roomList = new List<Room>();
            SelectedItem = new ReservationJoined();
            FetchData();
            GetData();
        }

        #region Field
        private string _target;
        private ICommand _searchCommand;
        private ICommand _cancleOrCheckoutCommand;
        private ICommand _checkinCommand;
        private ReservationCRUD _reservationRepo;
        private CustomerCRUD _customerRepo;
        private RoomCRUD _roomRepo;
        private HistoryCRUD _historyRepo;
        private List<Reservation> _reservationList;
        private List<Customer> _customerList;
        private List<Room> _roomList;
        private ReservationJoined _selectedItem;
        #endregion

        #region Properties
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(GetData);
                return _searchCommand;
            }
        }
        public ICommand CancleOrCheckoutCommand
        {
            get
            {
                _cancleOrCheckoutCommand ??= new ViewModelCommand(CancleOrCheckout);
                return _cancleOrCheckoutCommand;
            }
        }
        public ICommand CheckinCommand
        {
            get
            {
                _checkinCommand ??= new ViewModelCommand(Checkin);
                return _checkinCommand;
            }
        }
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        public ReservationJoined SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ReservationJoined> ItemSource { get; set; }
        #endregion

        #region Method
        private void FetchData()
        {
            _reservationList = null;
            _customerList = null;
            _roomList = null;
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

            if (string.IsNullOrEmpty(target.ToString()) || string.IsNullOrWhiteSpace(target.ToString()))
            {
                ItemSource = null;
                ItemSource = new ObservableCollection<ReservationJoined>(data);
            }
            else
            {
                ItemSource = null;
                ItemSource = new ObservableCollection<ReservationJoined>(
                    from x in data
                    where x.ReservationEntity.ResCode == target.ToString()
                    select x);
            }
        }
        public void CancleOrCheckout(object target)
        {
            var reservation = ((ReservationJoined)target).ReservationEntity;

            _reservationRepo.DeleteRecord(reservation);
            _historyRepo.InsertRecord(
                new History
                {
                    ResCode = reservation.ResCode,
                    ResCheckIn = reservation.ResCheckIn,
                    ResCheckOut = reservation.ResCheckOut,
                    ResIDCust = reservation.ResIDCust,
                    ResIDRoom = reservation.ResIDRoom,
                });

            FetchData();
            GetData();
        }
        public void Checkin(object target)
        {
            var reservation = ((ReservationJoined)target).ReservationEntity;

            reservation.ResStatus = ReservationStatus.Checkin;
            _reservationRepo.UpdateRecord(reservation);

            FetchData();
            GetData();
        }
        #endregion
    }
}