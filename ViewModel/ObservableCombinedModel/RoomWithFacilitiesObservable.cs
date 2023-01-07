using PinusPengger.ViewModel.ObservableCombinedModel;
using PinusPengger.ViewModel.ObservableModel;
using System.Collections.Generic;

namespace PinusPengger.ViewModel.ObservableCombinedModel
{
    internal class RoomWithFacilitiesObservable : ViewModelBase
    {
        private RoomObservable _room;
        private RoomFacilityObservable _roomFacility;
        private List<RoomFacilityBathroomObservable> _roomFacilityBathrooms;
        private List<RoomFacilityOtherObservable> _roomFacilityOthers;

        public RoomObservable Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }
        public RoomFacilityObservable RoomFacility
        {
            get => _roomFacility;
            set
            {
                _roomFacility = value;
                OnPropertyChanged();
            }
        }
        public List<RoomFacilityBathroomObservable> RoomFacilityBathrooms
        {
            get => _roomFacilityBathrooms;
            set
            {
                _roomFacilityBathrooms = value;
                OnPropertyChanged();
            }
        }
        public List<RoomFacilityOtherObservable> RoomFacilityOthers
        {
            get => _roomFacilityOthers;
            set
            {
                _roomFacilityOthers = value;
                OnPropertyChanged();
            }
        }
    }
}
