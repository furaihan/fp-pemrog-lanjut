namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Merepresentasikan data fasilitas kamar di database
    /// </summary>
    public class RoomFacility
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="RoomFacility"/>
        /// </summary>
        public RoomFacility()
        {
            _bed = string.Empty;
            _internet = string.Empty;
        }

        private Tag.RoomType _roomType;
        private string _bed;
        private string _internet;

        /// <summary>
        /// Merepresentasikan kolom tipe kamar pada tabel fasilitas kamar di database
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
        /// <summary>
        /// Merepresentasikan kolom spesifikasi tempat tidur pada tabel fasilitas kamar di database
        /// </summary>
        public string Bed
        {
            get => _bed;
            set => _bed = value;
        }
        /// <summary>
        /// Merepresentasikan kolom kecepatan internet pada tabel fasilitas kamar di database
        /// </summary>
        public string Internet
        {
            get => _internet;
            set => _internet = value;
        }
    }
}
