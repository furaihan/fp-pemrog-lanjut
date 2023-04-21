using System;

namespace PinusPengger.ViewModel.ObservableModel
{
    /// <summary>
    /// Represents an observable model for a hotel history entry.
    /// </summary>
    public class HistoryObservable : ViewModelBase
    {
        private int _historyID;
        private string _reservationCode;
        private byte _numberOfGuests;
        private DateTime _checkin;
        private DateTime _checkout;
        private int _customerID;
        private int _roomID;

        /// <summary>
        /// Initializes a new instance of the HistoryObservable class.
        /// </summary>
        public HistoryObservable()
        {
            _reservationCode = string.Empty;
        }

        /// <summary>
        /// Gets or sets the ID of the history entry.
        /// </summary>
        public int HistoryID
        {
            get => _historyID;
            set
            {
                _historyID = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the reservation code of the history entry.
        /// </summary>
        public string ReservationCode
        {
            get => _reservationCode;
            set
            {
                _reservationCode = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the number of guests for the history entry.
        /// </summary>
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                _numberOfGuests = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the check-in date and time of the history entry.
        /// </summary>
        public DateTime Checkin
        {
            get => _checkin;
            set
            {
                _checkin = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the check-out date and time of the history entry.
        /// </summary>
        public DateTime Checkout
        {
            get => _checkout;
            set
            {
                _checkout = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the ID of the customer associated with the history entry.
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the ID of the room associated with the history entry.
        /// </summary>
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
