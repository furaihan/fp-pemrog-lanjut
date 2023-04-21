using PinusPengger.Model;

namespace PinusPengger.ViewModel.ObservableModel
{
    /// <summary>
    /// Represents an observable object of a room in the Model namespace, which can be used in the ViewModel.
    /// </summary>
    public class RoomObservable : ViewModelBase
    {
        private int _roomID;
        private string _roomCode;
        private byte _roomFloor;
        private byte _roomNumber;
        private byte _squareMeter;
        Tag.RoomType _roomType;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomObservable"/> class.
        /// </summary>
        public RoomObservable()
        {
            _roomCode = string.Empty;
        }

        /// <summary>
        /// Gets or sets the ID of the room.
        /// </summary>
        public int RoomID
        {
            get => _roomID;
            set
            {
                _roomID = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the code of the room.
        /// </summary>
        public string RoomCode
        {
            get => _roomCode;
            set
            {
                _roomCode = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the floor number of the room.
        /// </summary>
        public byte RoomFloor
        {
            get => _roomFloor;
            set
            {
                _roomFloor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the room number of the room.
        /// </summary>
        public byte RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the square meter of the room.
        /// </summary>
        public byte SquareMeter
        {
            get => _squareMeter;
            set
            {
                _squareMeter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the type of the room.
        /// </summary>
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set
            {
                _roomType = value;
                OnPropertyChanged();
            }
        }

    }
}
