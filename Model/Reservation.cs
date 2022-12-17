using System;

namespace PinusPengger.Model
{
    /// <summary>
    /// Representasi dari record di dalam tabel reservasi
    /// </summary>
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

    /// <summary>
    /// Representasi dari kolom status reservasi
    /// </summary>
    enum ReservationStatus
    {
        Booking = 0,
        Checkin = 1,
    }
}
