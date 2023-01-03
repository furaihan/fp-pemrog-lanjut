using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.CombinedModel
{
    internal class HistoryJoined
    {
        public HistoryJoined()
        {
            _customer = new Customer();
            _room = new Room();
            _history = new History();
        }

        private Customer _customer;
        private Room _room;
        private History _history;

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
        public History History
        {
            get => _history;
            set => _history = value;
        }
    }
}
