using System;

namespace PinusPengger.Model
{
    internal class Reservation
    {
        public int? ResID { get; set; }
        public string ResCode { get; set; }
        public DateTime? ResCheckIn { get; set; }
        public DateTime? ResCheckOut { get; set; }
        public ReservationStatus? ResStatus { get; set; }
        public int? ResIDCust { get; set; }
        public int? ResIDRoom { get; set; }
    }

    enum ReservationStatus
    {
        Booking = 0,
        Checkin = 1,
    }
}
