namespace TestingDatabase.Model.EntityModel
{
    internal class Room
    {
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

        public int RoomID
        {
            get => _roomID;
            set => _roomID = value;
        }
        public string RoomCode
        {
            get => _roomCode;
            set => _roomCode = value;
        }
        public byte RoomFloor
        {
            get => _roomFloor;
            set => _roomFloor = value;
        }
        public byte RoomNumber
        {
            get => _roomNumber;
            set => _roomNumber = value;
        }
        public byte SquareMeter
        {
            get => _squareMeter;
            set => _squareMeter = value;
        }
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }
}
