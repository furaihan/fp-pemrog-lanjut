using Microsoft.IdentityModel.Tokens;
using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.ServiceAgent;
using PinusPengger.ViewModel.Helper;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayHistoriesVM : ViewModelBase, IBasePage
    {
        public DisplayHistoriesVM()
        {
            _target = string.Empty;
            _errorMessage = string.Empty;
            _searchCommand = new ViewModelCommand(param => ProcessData());
            _historyJoineds = Enumerable.Empty<HistoryJoined>();
            HistoryJoinedsObservable = new ObservableCollection<HistoryJoinedObservable>();
            _timer = new Timer(1000);
            _timeNow = DateTime.Now;
            _timer.Elapsed += (o, e) =>
            {
                TimeNow = DateTime.Now;
            };
            _timer.Start();
            GetData();
            ProcessData();
        }

        #region Field
        private string _target;
        private string _errorMessage;
        private ViewModelCommand _searchCommand;
        private IEnumerable<HistoryJoined> _historyJoineds;
        private Timer _timer;
        private DateTime? _timeNow;
        #endregion

        #region Properties
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public ViewModelCommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(param => ProcessData());
                return _searchCommand;
            }
        }
        public ObservableCollection<HistoryJoinedObservable> HistoryJoinedsObservable { get; set; }
        public DateTime? TimeNow
        {
            get => _timeNow;
            set
            {
                _timeNow = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Method
        public void GetData()
        {
            using (var historySA = new HistorySA())
            {
                try
                {
                    historySA.FetchData();
                    _historyJoineds = historySA.GetData().Cast<HistoryJoined>();
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }
        }
        public void ProcessData()
        {
            try
            {
                if (_historyJoineds.IsNullOrEmpty())
                {
                    throw new Exception("Data tidak ditemukan");
                }
                if (!_target.IsNullOrEmpty())
                {
                    _historyJoineds = _historyJoineds.Where(x => x.History.ReservationCode == _target);
                }

                HistoryJoinedsObservable.Clear();

                foreach (var item in _historyJoineds)
                {
                    HistoryJoinedsObservable.Add(new HistoryJoinedObservable
                    {
                        Customer = DataObservableConverter.FromCustomerEntity(item.Customer),
                        Room = DataObservableConverter.FromRoomEntity(item.Room),
                        History = DataObservableConverter.FromHistoryEntity(item.History)
                    });
                }

                Target = string.Empty;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            #endregion
        }
    }
}
