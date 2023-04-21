using System;

namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents a reservation data in the database
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class
        /// </summary>
        public Reservation()
        {
            _reservationCode = string.Empty;
        }

        private int _reservationID;
        private string _reservationCode;
        private byte _numberOfGuests;
        private DateTime _checkin;
        private DateTime _checkout;
        private Tag.ReservationStatus _reservationStatus;
        private int _customerID;
        private int _roomID;

        /// <summary>
        /// Represents the reservation ID column in the reservation table in the database
        /// </summary>
        public int ReservationID
        {
            get => _reservationID;
            set => _reservationID = value;
        }
        /// <summary>
        /// Represents the reservation code column in the reservation table in the database
        /// </summary>
        public string ReservationCode
        {
            get => _reservationCode;
            set => _reservationCode = value;
        }
        /// <summary>
        /// Represents the number of guests column in the reservation table in the database
        /// </summary>
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set => _numberOfGuests = value;
        }
        /// <summary>
        /// Represents the check-in date and time column in the reservation table in the database
        /// </summary>
        public DateTime Checkin
        {
            get => _checkin;
            set => _checkin = value;
        }
        /// <summary>
        /// Represents the check-out date and time column in the reservation table in the database
        /// </summary>
        public DateTime Checkout
        {
            get => _checkout;
            set => _checkout = value;
        }
        /// <summary>
        /// Represents the reservation status column in the reservation table in the database
        /// </summary>
        public Tag.ReservationStatus ReservationStatus
        {
            get => _reservationStatus;
            set => _reservationStatus = value;
        }
        /// <summary>
        /// Represents the customer ID column in the reservation table in the database
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        /// <summary>
        /// Represents the room ID column in the reservation table in the database
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
    }
}
