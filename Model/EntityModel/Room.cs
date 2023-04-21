namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents the data of a room in the database
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Initializes an object of type <see cref="Room"/>
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
        private Tag.RoomType _roomType;

        /// <summary>
        /// Represents the room ID column in the room table in the database
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
        /// <summary>
        /// Represents the room code column in the room table in the database
        /// </summary>
        public string RoomCode
        {
            get => _roomCode;
            set => _roomCode = value;
        }
        /// <summary>
        /// Represents the room floor column in the room table in the database
        /// </summary>
        public byte RoomFloor
        {
            get => _roomFloor;
            set => _roomFloor = value;
        }
        /// <summary>
        /// Represents the room number column for each floor in the room table in the database
        /// </summary>
        public byte RoomNumber
        {
            get => _roomNumber;
            set => _roomNumber = value;
        }
        /// <summary>
        /// Represents the room square meter column in the room table in the database
        /// </summary>
        public byte SquareMeter
        {
            get => _squareMeter;
            set => _squareMeter = value;
        }
        /// <summary>
        /// Represents the room type column in the room table in the database
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }

}
