using PinusPengger.ViewModel.ObservableModel;

namespace PinusPengger.ViewModel.ObservableCombinedModel
{
    /// <summary>
    /// Represents the observable object for a combined model in the Model.CombinedModel namespace.
    /// </summary>
    public class HistoryJoinedObservable : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryJoinedObservable"/> class.
        /// </summary>
        public HistoryJoinedObservable()
        {
            _customer = new CustomerObservable();
            _room = new RoomObservable();
            _history = new HistoryObservable();
        }

        private CustomerObservable _customer;
        private RoomObservable _room;
        private HistoryObservable _history;

        /// <summary>
        /// Gets or sets the observable object for the customer information.
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
        /// Gets or sets the observable object for the room information.
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
        /// Gets or sets the observable object for the history information.
        /// </summary>
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
