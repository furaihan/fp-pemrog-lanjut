using PinusPengger.Model.EntityModel;

namespace PinusPengger.Model.CombinedModel
{
    /// <summary>
    /// Represents a combination of <see cref="EntityModel.History"/>, <see cref="EntityModel.Customer"/>, and <see cref="EntityModel.Room"/>.
    /// </summary>
    public class HistoryJoined
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryJoined"/> class.
        /// </summary>
        public HistoryJoined()
        {
            _customer = new Customer();
            _room = new Room();
            _history = new History();
        }

        private Customer _customer;
        private Room _room;
        private History _history;

        /// <summary>
        /// Represents data about a customer who has checked out.
        /// </summary>
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
        /// <summary>
        /// Represents data about the room that a customer has reserved.
        /// </summary>
        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        /// <summary>
        /// Represents data about a customer's reservation history.
        /// </summary>
        public History History
        {
            get => _history;
            set => _history = value;
        }
    }
}
