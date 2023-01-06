using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.DataAccessLayer;
using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinusPengger.Model.ServiceAgent
{
    /// <summary>
    /// Layanan mengakses model <see cref="CombinedModel.HistoryJoined"/>
    /// </summary>
    internal class HistorySA : ServiceAgent, IDisposable
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="HistorySA"/>
        /// </summary>
        public HistorySA()
        {
            _customerDAL = new CustomerDAL();
            _roomDAL = new RoomDAL();
            _historyDAL = new HistoryDAL();
            _customers = new List<Customer>();
            _rooms = new List<Room>();
            _histories = new List<History>();
        }

        private CustomerDAL _customerDAL;
        private RoomDAL _roomDAL;
        private HistoryDAL _historyDAL;
        private List<Customer> _customers;
        private List<Room> _rooms;
        private List<History> _histories;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void FetchData()
        {
            // Fetch customer datas
            _customers = _customerDAL.ReadData().Cast<Customer>().ToList();

            // Fetch room datas
            _rooms = _roomDAL.ReadData().Cast<Room>().ToList();

            // Fetch history datas
            _histories = _historyDAL.ReadData().Cast<History>().ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override IEnumerable<object> GetData()
        {
            var result = from history in _histories
                         join customer in _customers on history.CustomerID equals customer.CustomerID
                         join room in _rooms on history.RoomID equals room.RoomID
                         select new HistoryJoined
                         {
                             Customer = customer,
                             Room = room,
                             History = history
                         };

            return result;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            _customerDAL.Dispose();
            _roomDAL.Dispose();
            _historyDAL.Dispose();
        }
    }
}
