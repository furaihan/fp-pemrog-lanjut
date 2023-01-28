using PinusPengger.ViewModel.ObservableCombinedModel;

namespace PinusPengger.ViewModel.PopUpVM
{
    public class DataKamarPopUpVM : ViewModelBase
    {
        private RoomWithFacilitiesObservable _roomDetails;

        public DataKamarPopUpVM()
        {
            _roomDetails = new RoomWithFacilitiesObservable();
            Mediator.Register("ShowDetailRoom", ShowDetailRoomWindow);
        }

        public RoomWithFacilitiesObservable RoomDetails
        {
            get => _roomDetails;
            set
            {
                _roomDetails = value;
                OnPropertyChanged();
            }
        }

        private void ShowDetailRoomWindow(object obj)
        {
            if (obj is RoomWithFacilitiesObservable arg)
            {
                RoomDetails = arg;
            }
        }
    }
}
