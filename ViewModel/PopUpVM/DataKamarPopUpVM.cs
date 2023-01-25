using PinusPengger.ViewModel.ObservableCombinedModel;

namespace PinusPengger.ViewModel.PopUpVM
{
    public class DataKamarPopUpVM : ViewModelBase
    {
        public DataKamarPopUpVM()
        {
            RoomDetails = new RoomWithFacilitiesObservable();
            Mediator.Register("ShowDetailRoom", ShowDetailRoomWindow);
        }

        public RoomWithFacilitiesObservable RoomDetails { get; set; }

        private void ShowDetailRoomWindow(object obj)
        {
            if (obj is RoomWithFacilitiesObservable arg)
            {
                RoomDetails = arg;
            }
        }
    }
}
