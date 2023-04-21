using PinusPengger.Model;

namespace PinusPengger.ViewModel.ObservableModel
{
    /// <summary>
    /// Represents an observable object for a room facility.
    /// </summary>
    public class RoomFacilityObservable : ViewModelBase
    {
        private Tag.RoomType _roomType;
        private string _bed;
        private string _internet;

        /// <summary>
        /// Initializes a new instance of the RoomFacilityObservable class.
        /// </summary>
        public RoomFacilityObservable()
        {
            _bed = string.Empty;
            _internet = string.Empty;
        }

        /// <summary>
        /// Gets or sets the type of room associated with the room facility.
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

        /// <summary>
        /// Gets or sets the type of bed associated with the room facility.
        /// </summary>
        public string Bed
        {
            get => _bed;
            set
            {
                _bed = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the internet availability associated with the room facility.
        /// </summary>
        public string Internet
        {
            get => _internet;
            set
            {
                _internet = value;
                OnPropertyChanged();
            }
        }

    }
}
