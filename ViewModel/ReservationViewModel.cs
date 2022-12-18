using PinusPengger.Model;
using PinusPengger.Records;
using PinusPengger.Repository;
using PinusPengger.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// View model untuk halaman reservasi
    /// </summary>
    internal class ReservationViewModel : ViewModelLogic
    {
        /// <summary>
        /// Menginisialisasi instance sekaligus mengambil data dari database
        /// </summary>
        public ReservationViewModel()
        {
            _customerRepo = new CustomerCRUD();
            _roomRepo = new RoomCRUD();
            _reservationRepo = new ReservationCRUD();
            CustomerRecord = new CustomerRecord();
            RoomRecord = new RoomRecord();
            _rooms = new List<Room>();
            _reservations = new List<Reservation>();
            RoomRecords = new ObservableCollection<RoomRecord>();
            RoomTypes = new List<RoomType>() { RoomType.Reg, RoomType.VIP };
            RegularRoom = new ObservableCollection<RegularRoom>();
            FetchData();
            ProcessData();
        }

        #region Field
        private ICommand _changeOptionCommand;
        private ICommand _reserveCommand;
        private ICommand _resetCommand;
        private DateTime? _checkin;
        private DateTime? _checkout;
        private RoomType _selectedType;
        #endregion

        #region Properties
        public ICommand ChangeOptionCommand
        {
            get
            {
                _changeOptionCommand ??= new ViewModelCommand(param => ProcessData());
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
        public RoomType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }
        public List<RoomType> RoomTypes { get; set; }
        public ObservableCollection<RegularRoom> RegularRoom { get; set; }
        #endregion

        #region Method
        private void RegularRoomInit()
        {
            int jumlahLantai = 8;
            List<int> junmlahKamar = new List<int>() { 8, 9, 6, 7, 8, 9, 6, 5 };
            for (int i = 0; i < jumlahLantai; i++)
            {

            }
        }
        protected override void FetchData()
        {
            _rooms = null;
            _reservations = null;
            _roomRepo.ReadData().ForEach(data => _rooms.Add(data));
            _reservationRepo.ReadData().ForEach(data => _reservations.Add(data));
        }
        public override void ProcessData()
        {
            // di view gunakan kondisi apabila id room ada di dalam reservasi maka warna merah
            var dataSelected = from room in _rooms
                               where room.RoomType == _selectedType
                               select room;

            dataSelected.ToList().ForEach(data => RoomRecords.Add(
                new RoomRecord
                {
                    ID = data.RoomID,
                    Code = data.RoomCode,
                    Number = data.RoomNumber,
                    Floor = data.RoomFloor,
                    Type = data.RoomType
                }));
        }
        /// <summary>
        /// Memesan kamar hotel
        /// </summary>
        /// <param name="status">
        /// Pilih salah satu dari <see cref="ReservationStatus"/> sebagai command parameter button
        /// </param>
        public void Reserve(object status)
        {
            _customer = new Customer
            {
                CustName = CustomerRecord.Name,
                CustNIK = CustomerRecord.NIK,
                CustBirthDate = CustomerRecord.BirthDate,
                CustPhone = CustomerRecord.Phone
            };
            _customerRepo.InsertRecord(_customer);

            _reservation = new Reservation
            {
                ResCode = null, //hasil generate random
                ResCheckIn = _checkin,
                ResCheckOut = _checkout,
                ResStatus = (ReservationStatus)status,
                ResIDCust = _customerRepo.ReadData().Last().CustID,
                ResIDRoom = RoomRecord.ID
            };
            _reservationRepo.InsertRecord(_reservation);
        }
        /// <summary>
        /// Membersihkan data
        /// </summary>
        public void Reset()
        {
            CustomerRecord.Name = null;
            CustomerRecord.NIK = null;
            CustomerRecord.BirthDate = null;
            CustomerRecord.Phone = null;
            Checkin = null;
            Checkout = null;
        }
        #endregion
    }
}
