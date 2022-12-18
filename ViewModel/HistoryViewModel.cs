using PinusPengger.Model;
using PinusPengger.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    class HistoryViewModel : ViewModelBase
    {
        public HistoryViewModel()
        {
            _historyRepo = new HistoryCRUD();
            _customerRepo = new CustomerCRUD();
            _roomRepo = new RoomCRUD();
            _historyList = new List<History>();
            _customerList = new List<Customer>();
            _roomList = new List<Room>();
            SelectedItem = new HistoryJoined();
            FetchData();
            GetData();
        }

        #region Field
        private string _target;
        private ICommand _searchCommand;
        private HistoryCRUD _historyRepo;
        private CustomerCRUD _customerRepo;
        private RoomCRUD _roomRepo;
        private List<History> _historyList;
        private List<Customer> _customerList;
        private List<Room> _roomList;
        private HistoryJoined _selectedItem;
        #endregion

        #region Properties
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(GetData);
                return _searchCommand;
            }
        }
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        public HistoryJoined SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<HistoryJoined> ItemSource { get; set; }
        #endregion

        #region Method
        private void FetchData()
        {
            _historyList = null;
            _customerList = null;
            _roomList = null;
            _historyRepo.ReadData().ForEach(data => _historyList.Add(data));
            _customerRepo.ReadData().ForEach(data => _customerList.Add(data));
            _roomRepo.ReadData().ForEach(data => _roomList.Add(data));
        }
        public void GetData(object target = null)
        {
            var data = from history in _historyList
                       join customer in _customerList on history.ResIDCust equals customer.CustID
                       join room in _roomList on history.ResIDRoom equals room.RoomID
                       select new HistoryJoined
                       {
                           HistoryEntity = history,
                           CustomerEntity = customer,
                           RoomEntity = room
                       };
            if (string.IsNullOrEmpty(target.ToString()) || string.IsNullOrWhiteSpace(target.ToString()))
            {
                ItemSource = null;
                ItemSource = new ObservableCollection<HistoryJoined>(data);
            }
            else
            {
                ItemSource = null;
                ItemSource = new ObservableCollection<HistoryJoined>(
                    from x in data
                    where x.HistoryEntity.ResCode == target.ToString()
                    select x);
                //var tes = data.Where(x => x.HistoryEntity.ResCode == target.ToString()).Select(x => x);
            }
        }
        #endregion
    }
}
