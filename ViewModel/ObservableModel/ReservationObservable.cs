using PinusPengger.Model;
using System;

namespace PinusPengger.ViewModel.ObservableModel
{
    ///<summary> 
    ///Represents an observable version of the Reservation model in the Model namespace. 
    ///</summary>
    public class ReservationObservable : ViewModelBase
    {
        private int _reservationID;
        private string _reservationCode;
        private byte _numberOfGuests;
        private DateTime _checkin;
        private DateTime _checkout;
        private Tag.ReservationStatus _reservationStatus;
        private int _customerID;
        private int _roomID;

        ///<summary> 
        ///Initializes a new instance of the ReservationObservable class. 
        ///</summary>
        public ReservationObservable()
        {
            _reservationCode = string.Empty;
        }

        ///<summary> 
        ///Gets or sets the ID of the reservation. 
        ///</summary>
        public int ReservationID
        {
            get => _reservationID;
            set
            {
                _reservationID = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the reservation code. 
        ///</summary>
        public string ReservationCode
        {
            get => _reservationCode;
            set
            {
                _reservationCode = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the number of guests for the reservation. 
        ///</summary>
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                _numberOfGuests = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the check-in date and time for the reservation. 
        ///</summary>
        public DateTime Checkin
        {
            get => _checkin;
            set
            {
                _checkin = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the check-out date and time for the reservation. 
        ///</summary>
        public DateTime Checkout
        {
            get => _checkout;
            set
            {
                _checkout = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the ID of the customer associated with the reservation. 
        ///</summary>
        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the ID of the room associated with the reservation. 
        ///</summary>
        public int RoomID
        {
            get => _roomID;
            set
            {
                _roomID = value;
                OnPropertyChanged();
            }
        }

        ///<summary> 
        ///Gets or sets the status of the reservation. 
        ///</summary>
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
