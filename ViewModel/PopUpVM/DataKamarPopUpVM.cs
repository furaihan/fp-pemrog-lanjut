using PinusPengger.ViewModel.ObservableCombinedModel;
using System.Diagnostics;
using System.Windows.Input;

namespace PinusPengger.ViewModel.PopUpVM
{
    public class DataKamarPopUpVM : ViewModelBase
    {
        private RoomWithFacilitiesObservable _roomDetails;
        private ICommand _onClose;

        public DataKamarPopUpVM()
        {
            _roomDetails = new RoomWithFacilitiesObservable();
            _onClose = new ViewModelCommand(ExecuteOnCloseCommand);
            Mediator.Register("ShowDetailRoom", ShowDetailRoomWindow);
        }
        public ICommand OnClose { get => _onClose; set => _onClose = value; }

        public RoomWithFacilitiesObservable RoomDetails
        {
            get => _roomDetails;
            set
            {
                _roomDetails = value;
                OnPropertyChanged();
            }
        }
        private void ExecuteOnCloseCommand(object obj)
        {
            Mediator.NotifyColleagues("IsDetailKamarWindowOpenChanged", false);
            Debug.WriteLine("Closing DataKamarPopUp");
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
