namespace TestingDatabase.Model.EntityModel
{
    internal class Reservation
    {
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

        public int ReservationID
        {
            get => _reservationID;
            set => _reservationID = value;
        }
        public string ReservationCode
        {
            get => _reservationCode;
            set => _reservationCode = value;
        }
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set => _numberOfGuests = value;
        }
        public DateTime Checkin
        {
            get => _checkin;
            set => _checkin = value;
        }
        public DateTime Checkout
        {
            get => _checkout;
            set => _checkout = value;
        }
        public Tag.ReservationStatus ReservationStatus
        {
            get => _reservationStatus;
            set => _reservationStatus = value;
        }
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
    }
}
