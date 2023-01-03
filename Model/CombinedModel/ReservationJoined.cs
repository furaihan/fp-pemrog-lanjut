using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.CombinedModel
{
    internal class ReservationJoined
    {
        public ReservationJoined()
        {
            _customer = new Customer();
            _room = new Room();
            _reservation = new Reservation();
        }

        private Customer _customer;
        private Room _room;
        private Reservation _reservation;

        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        public Reservation Reservation
        {
            get => _reservation;
            set => _reservation = value;
        }
    }
}
