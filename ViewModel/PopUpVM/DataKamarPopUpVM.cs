using PinusPengger.ViewModel.ObservableCombinedModel;
using System.Diagnostics;
using System.Windows.Input;

namespace PinusPengger.ViewModel.PopUpVM
{
    /// <summary>
    /// View model for the popup that displays details of a room.
    /// </summary>
    public class DataKamarPopUpVM : ViewModelBase
    {
        private RoomWithFacilitiesObservable _roomDetails;
        private ICommand _onClose;
        /// <summary>
        /// Initializes a new instance of the <see cref="DataKamarPopUpVM"/> class.
        /// </summary>
        public DataKamarPopUpVM()
        {
            _roomDetails = new RoomWithFacilitiesObservable();
            _onClose = new ViewModelCommand(ExecuteOnCloseCommand);
            Mediator.Register("ShowDetailRoom", ShowDetailRoomWindow);
        }
        /// <summary>
        /// Gets or sets the command to execute when the popup is closed.
        /// </summary>
        public ICommand OnClose { get => _onClose; set => _onClose = value; }
        /// <summary>
        /// Gets or sets the room details to display in the popup.
        /// </summary>
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
