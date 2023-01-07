using PinusPengger.ViewModel.ObservableModel;

namespace PinusPengger.ViewModel.ObservableCombinedModel
{
    public class ReservationJoinedObservable : ViewModelBase
    {
        public ReservationJoinedObservable()
        {
            _customer = new CustomerObservable();
            _room = new RoomObservable();
            _reservation = new ReservationObservable();
        }

        private CustomerObservable _customer;
        private RoomObservable _room;
        private ReservationObservable _reservation;

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
        internal ReservationObservable Reservation
        {
            get => _reservation;
            set
            {
                _reservation = value;
                OnPropertyChanged();
            }
        }
    }
}
