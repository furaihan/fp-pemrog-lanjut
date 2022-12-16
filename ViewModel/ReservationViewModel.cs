using PinusPengger.Model;
using PinusPengger.Records;
using PinusPengger.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    class ReservationViewModel : ViewModelBase
    {
        public ReservationViewModel()
        {
            RoomTypes = new List<RoomType>() { RoomType.Reg, RoomType.VIP };
            _roomRepo = new RoomCRUD();
            _customerRepo = new CustomerCRUD();
            _reservationRepo = new ReservationCRUD();
            _roomList = new List<Room>();
            _reservationList = new List<Reservation>();
            RoomDisplayed = new ObservableCollection<RoomRecord>();
            SelectedRoom = new RoomRecord();
            FetchData();
            GetData();
        }

        #region Field
        private ICommand _changeOptionCommand;
        private ICommand _reserveCommand;
        private ICommand _resetCommand;
        private RoomType _selectedType;
        private RoomCRUD _roomRepo;
        private CustomerCRUD _customerRepo;
        private ReservationCRUD _reservationRepo;
        private List<Reservation> _reservationList;
        private List<Room> _roomList;
        private RoomRecord _selectedRoom;
        private CustomerRecord _newCustomer;
        private Customer _customer;
        private Reservation _reservation;
        private DateTime? _checkin;
        private DateTime? _checkout;
        private ReservationStatus _status; // properti digunakan sebagai command parameter
        #endregion

        #region Properties
        public ICommand ChangeOptionCommand
        {
            get
            {
                _changeOptionCommand ??= new ViewModelCommand(param => GetData());
                return _changeOptionCommand;
            }
        }
        public ICommand ReserveCommand
        {
            get
            {
                _reserveCommand ??= new ViewModelCommand(param => Reserve(param));
                return _reserveCommand;
            }
        }
        public ICommand ResetCommand
        {
            get
            {
                _resetCommand ??= new ViewModelCommand(param => Reset());
                return _resetCommand;
            }
        }
        public RoomType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }
        public RoomRecord SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
            }
        }
        public CustomerRecord NewCustomer
        {
            get => _newCustomer;
            set
            {
                _newCustomer = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Checkin
        {
            get => _checkin;
            set
            {
                _checkin = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Checkout
        {
            get => _checkout;
            set
            {
                _checkout = value;
                OnPropertyChanged();
            }
        }
        public ReservationStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<RoomRecord> RoomDisplayed;
        public List<RoomType> RoomTypes { get; set; }
        #endregion

        #region Method
        private void FetchData()
        {
            _roomList = null;
            _reservationList = null;
            _roomRepo.ReadData().ForEach(data => _roomList.Add(data));
            _reservationRepo.ReadData().ForEach(data => _reservationList.Add(data));
        }
        public void GetData()
        {
            // di view gunakan kondisi apabila id room ada di dalam reservasi maka warna merah
            var dataSelected = from room in _roomList
                               where room.RoomType == _selectedType
                               select room;

            dataSelected.ToList().ForEach(data => RoomDisplayed.Add(
                new RoomRecord
                {
                    ID = data.RoomID,
                    Code = data.RoomCode,
                    Number = data.RoomNumber,
                    Floor = data.RoomFloor,
                    Type = data.RoomType
                }));
        }
        public void Reserve(object status)
        {
            _customer = new Customer
            {
                CustName = _newCustomer.Name,
                CustNIK = _newCustomer.NIK,
                CustBirthDate = _newCustomer.BirthDate,
                CustPhone = _newCustomer.Phone
            };
            _customerRepo.InsertRecord(_customer);

            _reservation = new Reservation
            {
                ResCode = null, //hasil generate random
                ResCheckIn = _checkin,
                ResCheckOut = _checkout,
                ResStatus = (ReservationStatus)status,
                ResIDCust = _customerRepo.ReadData().Last().CustID ?? default(int),
                ResIDRoom = SelectedRoom.ID ?? default(int)
            };
            _reservationRepo.InsertRecord(_reservation);
        }
        public void Reset()
        {
            _newCustomer.Name = null;
            _newCustomer.NIK = null;
            _newCustomer.BirthDate = null;
            _newCustomer.Phone = null;
            Checkin = null;
            Checkout = null;
        }
        #endregion
    }
}
