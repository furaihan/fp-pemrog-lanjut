using PinusPengger.Model;

namespace PinusPengger.ViewModel.ObservableModel
{
    public class RoomFacilityObservable : ViewModelBase
    {
        private Tag.RoomType _roomType;
        private string _bed;
        private string _internet;

        public RoomFacilityObservable()
        {
            _bed = string.Empty;
            _internet = string.Empty;
        }

        public string Bed
        {
            get => _bed;
            set
            {
                _bed = value;
                OnPropertyChanged();
            }
        }
        public string Internet
        {
            get => _internet;
            set
            {
                _internet = value;
                OnPropertyChanged();
            }
        }
        internal Tag.RoomType RoomType
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
