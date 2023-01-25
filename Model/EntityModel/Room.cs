namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Merepresentasikan data sebuah kamar di database
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="Room"/>
        /// </summary>
        public Room()
        {
            _roomCode = string.Empty;
        }

        private int _roomID;
        private string _roomCode;
        private byte _roomFloor;
        private byte _roomNumber;
        private byte _squareMeter;
        Tag.RoomType _roomType;

        /// <summary>
        /// Merepresentasikan kolom id kamar pada tabel kamar di database
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
        /// <summary>
        /// Merepresentasikan kolom kode kamar pada tabel kamar di database
        /// </summary>
        public string RoomCode
        {
            get => _roomCode;
            set => _roomCode = value;
        }
        /// <summary>
        /// Merepresentasikan kolom letak lantai kamar pada tabel kamar di database
        /// </summary>
        public byte RoomFloor
        {
            get => _roomFloor;
            set => _roomFloor = value;
        }
        /// <summary>
        /// Merepresentasikan kolom nomor kamar tiap lantai pada tabel kamar di database
        /// </summary>
        public byte RoomNumber
        {
            get => _roomNumber;
            set => _roomNumber = value;
        }
        /// <summary>
        /// Merepresentasikan kolom luas kamar pada tabel kamar di database
        /// </summary>
        public byte SquareMeter
        {
            get => _squareMeter;
            set => _squareMeter = value;
        }
        /// <summary>
        /// Merepresentasikan kolom tipe kamar pada tabel kamar di database
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }
}
