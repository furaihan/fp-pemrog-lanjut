using PinusPengger.ViewModel.ObservableModel;

namespace PinusPengger.ViewModel.ObservableCombinedModel
{
    /// <summary>
    /// Represents the observable object of the combined model ReservationJoined in the Model.CombinedModel namespace.
    /// </summary>
    public class ReservationJoinedObservable : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ReservationJoinedObservable class.
        /// </summary>
        public ReservationJoinedObservable()
        {
            _customer = new CustomerObservable();
            _room = new RoomObservable();
            _reservation = new ReservationObservable();
        }

        private CustomerObservable _customer;
        private RoomObservable _room;
        private ReservationObservable _reservation;

        /// <summary>
        /// Gets or sets the CustomerObservable object in the ReservationJoinedObservable.
        /// </summary>
        public CustomerObservable Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the RoomObservable object in the ReservationJoinedObservable.
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
        /// Gets or sets the ReservationObservable object in the ReservationJoinedObservable.
        /// </summary>
        public ReservationObservable Reservation
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
