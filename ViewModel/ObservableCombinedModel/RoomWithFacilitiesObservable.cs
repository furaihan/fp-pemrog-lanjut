using PinusPengger.ViewModel.ObservableModel;
using System.Collections.Generic;

namespace PinusPengger.ViewModel.ObservableCombinedModel
{
    /// <summary>
    /// Represents an observable object for a room with its facilities.
    /// </summary>
    public class RoomWithFacilitiesObservable : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomWithFacilitiesObservable"/> class.
        /// </summary>
        public RoomWithFacilitiesObservable()
        {
            _room = new RoomObservable();
            _roomFacility = new RoomFacilityObservable();
            _roomFacilityBathrooms = new List<RoomFacilityBathroomObservable>();
            _roomFacilityOthers = new List<RoomFacilityOtherObservable>();
        }

        private RoomObservable _room;
        private RoomFacilityObservable _roomFacility;
        private List<RoomFacilityBathroomObservable> _roomFacilityBathrooms;
        private List<RoomFacilityOtherObservable> _roomFacilityOthers;
        private bool _isBusy;

        /// <summary>
        /// Gets or sets the observable object for a room.
        /// </summary>
        public RoomObservable Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the observable object for the room facility.
        /// </summary>
        public RoomFacilityObservable RoomFacility
        {
            get => _roomFacility;
            set
            {
                _roomFacility = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the list of observable objects for room bathroom facilities.
        /// </summary>
        public List<RoomFacilityBathroomObservable> RoomFacilityBathrooms
        {
            get => _roomFacilityBathrooms;
            set
            {
                _roomFacilityBathrooms = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the list of observable objects for other room facilities.
        /// </summary>
        public List<RoomFacilityOtherObservable> RoomFacilityOthers
        {
            get => _roomFacilityOthers;
            set
            {
                _roomFacilityOthers = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the room is busy.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
    }
}
