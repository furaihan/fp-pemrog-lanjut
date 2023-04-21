using System;

namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents a data of a history in the database
    /// </summary>
    public class History
    {
        /// <summary>
        /// Initializes an object of <see cref="History"/>
        /// </summary>
        public History()
        {
            _reservationCode = string.Empty;
        }

        private int _historyID;
        private string _reservationCode;
        private byte _numberOfGuests;
        private DateTime _checkin;
        private DateTime _checkout;
        private int _customerID;
        private int _roomID;

        /// <summary>
        /// Represents the column of history ID in the history table in the database
        /// </summary>
        public int HistoryID
        {
            get => _historyID;
            set => _historyID = value;
        }
        /// <summary>
        /// Represents the column of reservation code in the history table in the database
        /// </summary>
        public string ReservationCode
        {
            get => _reservationCode;
            set => _reservationCode = value;
        }
        /// <summary>
        /// Represents the column of number of guests in the history table in the database
        /// </summary>
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set => _numberOfGuests = value;
        }
        /// <summary>
        /// Represents the column of check-in date and time in the history table in the database
        /// </summary>
        public DateTime Checkin
        {
            get => _checkin;
            set => _checkin = value;
        }
        /// <summary>
        /// Represents the column of check-out date and time in the history table in the database
        /// </summary>
        public DateTime Checkout
        {
            get => _checkout;
            set => _checkout = value;
        }
        /// <summary>
        /// Represents the column of customer ID in the history table in the database
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        /// <summary>
        /// Represents the column of room ID in the history table in the database
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
    }

}
