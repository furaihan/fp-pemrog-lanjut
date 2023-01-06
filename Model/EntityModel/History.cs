using System;

namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Merepresentasikan data sebuah riwayat di database
    /// </summary>
    internal class History
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="History"/>
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
        /// Merepresentasikan kolom id riwayat pada tabel riwayat di database
        /// </summary>
        public int HistoryID
        {
            get => _historyID;
            set => _historyID = value;
        }
        /// <summary>
        /// Merepresentasikan kolom kode reservasi pada tabel riwayat di database
        /// </summary>
        public string ReservationCode
        {
            get => _reservationCode;
            set => _reservationCode = value;
        }
        /// <summary>
        /// Merepresentasikan kolom jumlah tamu pada tabel riwayat di database
        /// </summary>
        public byte NumberOfGuests
        {
            get => _numberOfGuests;
            set => _numberOfGuests = value;
        }
        /// <summary>
        /// Merepresentasikan kolom tanggal dan waktu checkin pada tabel riwayat di database
        /// </summary>
        public DateTime Checkin
        {
            get => _checkin;
            set => _checkin = value;
        }
        /// <summary>
        /// Merepresentasikan kolom tanggal dan waktu checkout pada tabel riwayat di database
        /// </summary>
        public DateTime Checkout
        {
            get => _checkout;
            set => _checkout = value;
        }
        /// <summary>
        /// Merepresentasikan kolom id pelanggan pada tabel riwayat di database
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        /// <summary>
        /// Merepresentasikan kolom id kamar pada tabel riwayat di database
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
    }
}
