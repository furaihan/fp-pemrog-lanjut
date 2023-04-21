using PinusPengger.Model;

namespace PinusPengger.ViewModel.ObservableModel
{
    /// <summary>
    /// Represents an observable object of the bathroom facilities of a room in the Model namespace.
    /// </summary>
    public class RoomFacilityBathroomObservable : ViewModelBase
    {
        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        /// <summary>
        /// Initializes a new instance of the RoomFacilityBathroomObservable class.
        /// </summary>
        public RoomFacilityBathroomObservable()
        {
            _nameOfFacility = string.Empty;
        }

        /// <summary>
        /// Gets or sets the name of the bathroom facility.
        /// </summary>
        public string NameOfFacility
        {
            get => _nameOfFacility;
            set
            {
                _nameOfFacility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the room type of the bathroom facility.
        /// </summary>
        /// <seealso cref="Tag.RoomType"/>
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
