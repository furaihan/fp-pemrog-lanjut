namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Merepresentasikan data fasilitas lainnya di database
    /// </summary>
    public class RoomFacilityOther
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="RoomFacilityOther"/>
        /// </summary>
        public RoomFacilityOther()
        {
            _nameOfFacility = string.Empty;
        }

        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        /// <summary>
        /// Merepresentasikan kolom nama fasilitas pada tabel fasilitas lainnya di database
        /// </summary>
        public string NameOfFacility
        {
            get => _nameOfFacility;
            set => _nameOfFacility = value;
        }
        /// <summary>
        /// Merepresentasikan kolom tipe kamar pada tabel fasilitas lainnya di database
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }
}
