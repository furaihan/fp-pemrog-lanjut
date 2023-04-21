namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents room facility data in the database
    /// </summary>
    public class RoomFacility
    {
        /// <summary>
        /// Initializes an instance of <see cref="RoomFacility"/>
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
        /// Represents the room type column in the room facility table in the database
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
        /// <summary>
        /// Represents the bed specification column in the room facility table in the database
        /// </summary>
        public string Bed
        {
            get => _bed;
            set => _bed = value;
        }
        /// <summary>
        /// Represents the internet speed column in the room facility table in the database
        /// </summary>
        public string Internet
        {
            get => _internet;
            set => _internet = value;
        }
    }

}
