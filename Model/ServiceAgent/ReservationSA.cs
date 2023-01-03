using TestingDatabase.Model.CombinedModel;
using TestingDatabase.Model.DataAccessLayer;
using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.ServiceAgent
{
    internal class ReservationSA : ServiceAgent, IDisposable
    {
        public ReservationSA()
        {
            _customerDAL = new CustomerDAL();
            _roomDAL = new RoomDAL();
            _reservationDAL = new ReservationDAL();
            _customers = new List<Customer>();
            _rooms = new List<Room>();
            _reservations = new List<Reservation>();
        }

        private CustomerDAL _customerDAL;
        private RoomDAL _roomDAL;
        private ReservationDAL _reservationDAL;
        private List<Customer> _customers;
        private List<Room> _rooms;
        private List<Reservation> _reservations;

        public override void FetchData()
        {
            // Fetch customer datas
            _customers = _customerDAL.ReadData().Cast<Customer>().ToList();

            // Fetch room datas
            _rooms = _roomDAL.ReadData().Cast<Room>().ToList();

            // Fetch reservation datas
            _reservations = _reservationDAL.ReadData().Cast<Reservation>().ToList();
        }

        public override IEnumerable<object> GetData()
        {
            var result = from reservation in _reservations
                         join customer in _customers on reservation.CustomerID equals customer.CustomerID
                         join room in _rooms on reservation.RoomID equals room.RoomID
                         select new ReservationJoined
                         {
                             Customer = customer,
                             Room = room,
                             Reservation = reservation
                         };

            return result;
        }

        public void Dispose()
        {
            _customerDAL.Dispose();
            _roomDAL.Dispose();
            _reservationDAL.Dispose();
        }
    }
}
