namespace TestingDatabase.Model.EntityModel
{
    internal class History
    {
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

        public int HistoryID
        {
            get => _historyID;
            set => _historyID = value;
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
