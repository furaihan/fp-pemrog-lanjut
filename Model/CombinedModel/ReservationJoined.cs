using PinusPengger.Model.EntityModel;

namespace PinusPengger.Model.CombinedModel
{
    /// <summary>
    /// Represents a combination of <see cref="EntityModel.Reservation"/> with <see cref="EntityModel.Customer"/> and <see cref="EntityModel.Room"/>.
    /// </summary>
    public class ReservationJoined
    {
        /// <summary>
        /// Initializes an instance of <see cref="ReservationJoined"/>.
        /// </summary>
        public ReservationJoined()
        {
            _customer = new Customer();
            _room = new Room();
            _reservation = new Reservation();
        }

        private Customer _customer;
        private Room _room;
        private Reservation _reservation;

        /// <summary>
        /// Represents the data of a customer who is currently making a reservation.
        /// </summary>
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        /// <summary>
        /// Represents the data of a room that is currently being reserved by the customer.
        /// </summary>
        public Room Room
        {
            get => _room;
            set => _room = value;
        }

        /// <summary>
        /// Represents the data of a reservation made by the customer.
        /// </summary>
        public Reservation Reservation
        {
            get => _reservation;
            set => _reservation = value;
        }
    }
}
