using PinusPengger.Model;
using PinusPengger.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// View model untuk halaman riwayat
    /// </summary>
    class HistoryViewModel : ViewModelLogic
    {
        /// <summary>
        /// Menginisialisasi instance sekaligus mengambil data dari database
        /// </summary>
        public HistoryViewModel()
        {
            _historyRepo = new HistoryCRUD();
            _customerRepo = new CustomerCRUD();
            _roomRepo = new RoomCRUD();
            _histories = new List<History>();
            _customers = new List<Customer>();
            _rooms = new List<Room>();
            HistoryJoined = new HistoryJoined();
            HistoryJoineds = new ObservableCollection<HistoryJoined>();
            FetchData();
            ProcessData();
        }

        #region Field
        private string _target = string.Empty;
        private ICommand _searchCommand;
        #endregion

        #region Properties
        public string MessageError { get; set; }
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(param => ProcessData());
                return _searchCommand;
            }
        }
        #endregion

        #region Method
        protected override void FetchData()
        {
            _histories = null;
            _customers = null;
            _rooms = null;

            try
            {
                _historyRepo.ReadData().ForEach(data => _histories.Add(data));
                _customerRepo.ReadData().ForEach(data => _customers.Add(data));
                _roomRepo.ReadData().ForEach(data => _rooms.Add(data));
            }
            catch (Exception e)
            {
                MessageError = e.Message;
            }
        }

        public override void ProcessData()
        {
            var data = from history in _histories
                       join customer in _customers on history.ResIDCust equals customer.CustID
                       join room in _rooms on history.ResIDRoom equals room.RoomID
                       select new HistoryJoined
                       {
                           HistoryEntity = history,
                           CustomerEntity = customer,
                           RoomEntity = room
                       };

            if (string.IsNullOrEmpty(_target.ToString()) || string.IsNullOrWhiteSpace(_target.ToString()))
            {
                HistoryJoineds = null;
                HistoryJoineds = new ObservableCollection<HistoryJoined>(data);
            }
            else
            {
                HistoryJoineds = null;
                HistoryJoineds = new ObservableCollection<HistoryJoined>(
                    from x in data
                    where x.HistoryEntity.ResCode == _target.ToString()
                    select x);
            }

            _target = string.Empty;
        }
        #endregion
    }
}
