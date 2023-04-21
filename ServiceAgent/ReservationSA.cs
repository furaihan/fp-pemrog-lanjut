using PinusPengger.DataAccessLayer;
using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinusPengger.ServiceAgent
{
    /// <summary>
    /// A service to access the <see cref="CombinedModel.ReservationJoined"/> model
    /// </summary>
    public class ReservationSA : ServiceAgent, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationSA"/> class
        /// </summary>
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void FetchData()
        {
            // Fetch customer datas
            _customers = _customerDAL.ReadData().Cast<Customer>().ToList();

            // Fetch room datas
            _rooms = _roomDAL.ReadData().Cast<Room>().ToList();

            // Fetch reservation datas
            _reservations = _reservationDAL.ReadData().Cast<Reservation>().ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
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
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _customerDAL.Dispose();
            _roomDAL.Dispose();
            _reservationDAL.Dispose();
        }
    }
}
