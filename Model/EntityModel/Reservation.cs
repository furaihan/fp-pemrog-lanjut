using System;

namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Meresentasikan data sebuah reservasi di database
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="Reservation"/>
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
        /// Merepresentasikan kolom id reservasi pada tabel reservasi di database
        /// </summary>
        public int ReservationID
        {
            get => _reservationID;
            set => _reservationID = value;
        }
        /// <summary>
        /// Merepresentasikan kolom kode reservasi pada tabel reservasi di database
        /// </summary>
        public string ReservationCode
        {
            get => _reservationCode;
            set => _reservationCode = value;
        }
        /// <summary>
        /// Merepresentasikan kolom jumlah tamu pada tabel reservasi di database
        /// </summary>
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set => _numberOfGuests = value;
        }
        /// <summary>
        /// Merepresentasikan kolom tanggal dan waktu checkin pada tabel reservasi di database
        /// </summary>
        public DateTime Checkin
        {
            get => _checkin;
            set => _checkin = value;
        }
        /// <summary>
        /// Merepresentasikan kolom tanggal dan waktu checkout pada tabel reservasi di database
        /// </summary>
        public DateTime Checkout
        {
            get => _checkout;
            set => _checkout = value;
        }
        /// <summary>
        /// Merepresentasikan kolom status reservasi pada tabel reservasi di database
        /// </summary>
        public Tag.ReservationStatus ReservationStatus
        {
            get => _reservationStatus;
            set => _reservationStatus = value;
        }
        /// <summary>
        /// Merepresentasikan kolom id pelanggan pada tabel reservasi di database
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        /// <summary>
        /// Merepresentasikan kolom id kamar pada tabel reservasi di database
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
    }
}
