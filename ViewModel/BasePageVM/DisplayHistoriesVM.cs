using Microsoft.IdentityModel.Tokens;
using PinusPengger.Model.CombinedModel;
using PinusPengger.ServiceAgent;
using PinusPengger.ViewModel.Helper;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;

namespace PinusPengger.ViewModel.BasePageVM
{
    /// <summary>
    /// View model for displaying histories data on a page.
    /// </summary>
    public class DisplayHistoriesVM : ViewModelBase, IBasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayHistoriesVM"/> class.
        /// </summary>
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
        /// <summary>
        /// Gets or sets the search target.
        /// </summary>
        public string Target
        {
            get => _target;
            set
            {
                _target = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
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
        ///<summary>
        /// Retrieves data from the database through the HistorySA object.
        /// Stores the retrieved data in the _historyJoineds field.
        /// In case of an exception, sets the error message in the ErrorMessage property.
        ///</summary>
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
        ///<summary>
        /// Processes the data stored in the _historyJoineds field.
        /// Filters the data based on the value of the _target field.
        /// Clears the <see cref="HistoryJoinedsObservable"/> and populates it with new data based on the filtered results.
        /// In case of an exception, sets the error message in the <see cref="ErrorMessage"/> property.
        ///</summary>
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
