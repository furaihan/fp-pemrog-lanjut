using PinusPengger.ViewModel.ObservableModel;

namespace PinusPengger.ViewModel.ObservableCombinedModel
{
    public class HistoryJoinedObservable : ViewModelBase
    {
        public HistoryJoinedObservable()
        {
            _customer = new CustomerObservable();
            _room = new RoomObservable();
            _history = new HistoryObservable();
        }

        private CustomerObservable _customer;
        private RoomObservable _room;
        private HistoryObservable _history;

        public CustomerObservable Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }
        public RoomObservable Room
        {
            get => _room;
            set
            {
                _room = value;
                OnPropertyChanged();
            }
        }
        public HistoryObservable History
        {
            get => _history;
            set
            {
                _history = value;
                OnPropertyChanged();
            }
        }
    }
}
