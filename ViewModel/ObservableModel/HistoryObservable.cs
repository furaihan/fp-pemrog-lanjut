using System;

namespace PinusPengger.ViewModel.ObservableModel
{
    public class HistoryObservable : ViewModelBase
    {
        private int _historyID;
        private string _reservationCode;
        private byte _numberOfGuests;
        private DateTime _checkin;
        private DateTime _checkout;
        private int _customerID;
        private int _roomID;

        public HistoryObservable()
        {
            _reservationCode = string.Empty;
        }

        public int HistoryID
        {
            get => _historyID;
            set
            {
                _historyID = value;
                OnPropertyChanged();
            }
        }
        public string ReservationCode
        {
            get => _reservationCode;
            set
            {
                _reservationCode = value;
                OnPropertyChanged();
            }
        }
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                _numberOfGuests = value;
                OnPropertyChanged();
            }
        }
        public DateTime Checkin
        {
            get => _checkin;
            set
            {
                _checkin = value;
                OnPropertyChanged();
            }
        }
        public DateTime Checkout
        {
            get => _checkout;
            set
            {
                _checkout = value;
                OnPropertyChanged();
            }
        }
        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }
        public int RoomID
        {
            get => _roomID;
            set
            {
                _roomID = value;
                OnPropertyChanged();
            }
        }
    }
}
