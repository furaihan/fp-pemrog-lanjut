using PinusPengger.Model;
using System;

namespace PinusPengger.ViewModel.ObservableModel
{
    internal class ReservationObservable : ViewModelBase
    {
        private int _reservationID;
        private string _reservationCode;
        private byte _numberOfGuests;
        private DateTime _checkin;
        private DateTime _checkout;
        private Tag.ReservationStatus _reservationStatus;
        private int _customerID;
        private int _roomID;

        public ReservationObservable()
        {
            _reservationCode = string.Empty;
        }

        public int ReservationID
        {
            get => _reservationID;
            set
            {
                _reservationID = value;
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
        internal Tag.ReservationStatus ReservationStatus
        {
            get => _reservationStatus;
            set
            {
                _reservationStatus = value;
                OnPropertyChanged();
            }
        }
    }
}
