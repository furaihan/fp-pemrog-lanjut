namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents the data of other facilities in the database.
    /// </summary>
    public class RoomFacilityOther
    {
        /// <summary>
        /// Initializes an instance of <see cref="RoomFacilityOther"/>.
        /// </summary>
        public RoomFacilityOther()
        {
            _nameOfFacility = string.Empty;
        }

        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        /// <summary>
        /// Represents the facility name column in the other facilities table in the database.
        /// </summary>
        public string NameOfFacility
        {
            get => _nameOfFacility;
            set => _nameOfFacility = value;
        }

        /// <summary>
        /// Represents the room type column in the other facilities table in the database.
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }
}
