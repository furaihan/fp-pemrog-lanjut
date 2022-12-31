using PinusPengger.Model;
using PinusPengger.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// ViewModel untuk halaman home
    /// </summary>
    internal class HomeViewModel : ViewModelLogic
    {
        /// <summary>
        /// Menginisialisasi instance sekaligus mengambil data dari database
        /// </summary>
        public HomeViewModel()
        {
            _reservationRepo = new ReservationCRUD();
            _customerRepo = new CustomerCRUD();
            _roomRepo = new RoomCRUD();
            _historyRepo = new HistoryCRUD();
            _reservations = new List<Reservation>();
            _customers = new List<Customer>();
            _rooms = new List<Room>();
            ReservationJoined = new ReservationJoined();
            ReservationJoineds = new ObservableCollection<ReservationJoined>();
            Debug.WriteLine($"RJ-45: {ReservationJoineds.Count}");
            FetchData();
            ProcessData();
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
                _searchCommand ??= new ViewModelCommand(param => ProcessData());
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
        protected override void FetchData()
        {
            _reservations.Clear();
            _customers.Clear();
            _rooms.Clear();

            try
            {
                _reservationRepo.ReadData().ForEach(data => _reservations.Add(data));
                _customerRepo.ReadData().ForEach(data => _customers.Add(data));
                _roomRepo.ReadData().ForEach(data => _rooms.Add(data));
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        public override void ProcessData()
        {
            var data = from reservation in _reservations
                       join customer in _customers on reservation.ResIDCust equals customer.CustID
                       join room in _rooms on reservation.ResIDRoom equals room.RoomID
                       select new ReservationJoined
                       {
                           ReservationEntity = reservation,
                           CustomerEntity = customer,
                           RoomEntity = room
                       };

            if (string.IsNullOrEmpty(_target.ToString()) || string.IsNullOrWhiteSpace(_target.ToString()))
            {
                ReservationJoineds = null;
                ReservationJoineds = new ObservableCollection<ReservationJoined>(data);
            }
            else
            {
                ReservationJoineds = null;
                ReservationJoineds = new ObservableCollection<ReservationJoined>(
                    from x in data
                    where x.ReservationEntity.ResCode == _target.ToString()
                    select x);
            }

            Target = string.Empty;
        }
        /// <summary>
        /// Memperbarui status item terpilih menjadi checkin
        /// </summary>
        public void Checkin()
        {
            var reservation = ReservationJoined.ReservationEntity;

            try
            {
                reservation.ResStatus = ReservationStatus.Checkin;
                _reservationRepo.UpdateRecord(reservation);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }

            FetchData();
            ProcessData();
        }
        /// <summary>
        /// Menghapus item dari tabel reservasi
        /// </summary>
        public void Cancel()
        {
            var reservation = ReservationJoined.ReservationEntity;

            try
            {
                _reservationRepo.DeleteRecord(reservation);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }

            FetchData();
            ProcessData();
        }
        /// <summary>
        /// Menghapus item dari tabel reservasi sekaligus memasukkan item ke tabel riwayat
        /// </summary>
        public void Checkout()
        {
            var reservation = ReservationJoined.ReservationEntity;

            try
            {
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
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }

            FetchData();
            ProcessData();
        }
        #endregion
    }
}