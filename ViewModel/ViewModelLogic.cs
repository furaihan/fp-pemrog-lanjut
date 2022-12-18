using PinusPengger.Model;
using PinusPengger.Records;
using PinusPengger.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// Logika dasar dari view model
    /// </summary>
    internal abstract class ViewModelLogic : ViewModelBase
    {
        #region Field
        // models
        protected Customer _customer;
        protected History _history;
        protected Reservation _reservation;
        protected Room _room;
        protected List<Customer> _customers;
        protected List<History> _histories;
        protected List<Reservation> _reservations;
        protected List<Room> _rooms;

        // repositories
        protected CustomerCRUD _customerRepo;
        protected HistoryCRUD _historyRepo;
        protected ReservationCRUD _reservationRepo;
        protected RoomCRUD _roomRepo;
        #endregion

        #region Properties
        // records
        public CustomerRecord CustomerRecord { get; set; }
        public HistoryRecord HistoryRecord { get; set; }
        public ReservationRecord ReservationRecord { get; set; }
        public RoomRecord RoomRecord { get; set; }
        public ObservableCollection<CustomerRecord> CustomerRecords { get; set; }
        public ObservableCollection<HistoryRecord> HistoryRecords { get; set; }
        public ObservableCollection<ReservationRecord> ReservationRecords { get; set; }
        public ObservableCollection<RoomRecord> RoomRecords { get; set; }

        // joined records
        public ReservationJoined ReservationJoined { get; set; }
        public HistoryJoined HistoryJoined { get; set; }
        public ObservableCollection<ReservationJoined> ReservationJoineds { get; set; }
        public ObservableCollection<HistoryJoined> HistoryJoineds { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// Mengambil data dari database
        /// </summary>
        protected abstract void FetchData();
        /// <summary>
        /// Memproses data yang akan ditampilkan
        /// </summary>
        public abstract void ProcessData();
        #endregion
    }
}
