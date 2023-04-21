namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents bathroom facilities data in the database.
    /// </summary>
    public class RoomFacilityBathroom
    {
        /// <summary>
        /// Initializes an instance of <see cref="RoomFacilityBathroom"/>.
        /// </summary>
        public RoomFacilityBathroom()
        {
            _nameOfFacility = string.Empty;
        }

        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        /// <summary>
        /// Represents the name of the facility column in the bathroom facilities table in the database.
        /// </summary>
        public string NameOfFacility
        {
            get => _nameOfFacility;
            set => _nameOfFacility = value;
        }
        /// <summary>
        /// Represents the room type column in the bathroom facilities table in the database.
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }

}
