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
    /// The DisplayReservationsVM class represents the view model for a page
    /// </summary>
    public class DisplayReservationsVM : ViewModelBase, IBasePage
    {
        /// <summary>
        /// Initializes a new instance of the DisplayReservationsVM class.
        /// </summary>
        public DisplayReservationsVM()
        {
            _target = string.Empty;
            _errorMessage = string.Empty;
            _searchCommand = new ViewModelCommand(param => ProcessData());
            _reservationJoineds = Enumerable.Empty<ReservationJoined>();
            _timer = new Timer(1000);
            _timer.Elapsed += (o, e) =>
            {
                TimeNow = DateTime.Now;
            };
            _timer.Start();
            ReservationJoinedsObservable = new ObservableCollection<ReservationJoinedObservable>();
            GetData();
            ProcessData();
        }

        #region Field
        private string _target;
        private string _errorMessage;
        private ViewModelCommand _searchCommand;
        private IEnumerable<ReservationJoined> _reservationJoineds;
        private Timer _timer;
        private DateTime _timeNow = DateTime.Now;
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
        /// Gets or sets the error message to be displayed to the user.
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
        /// <summary>
        /// Gets the search command, which executes the ProcessData method.
        /// </summary>
        public ViewModelCommand SearchCommand
        {
            get
            {
                _searchCommand ??= new ViewModelCommand(param => ProcessData());
                return _searchCommand;
            }
        }
        /// <summary>
        /// Gets or sets the list of reservation joineds.
        /// </summary>
        public ObservableCollection<ReservationJoinedObservable> ReservationJoinedsObservable { get; set; }
        /// <summary>
        /// Gets or sets the time now.
        /// </summary>
        public DateTime TimeNow
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
        /// <summary>
        /// Retrieves data from the database and sets the _reservationJoineds field to the result.
        /// </summary>
        public void GetData()
        {
            using (var reservationSA = new ReservationSA())
            {
                try
                {
                    reservationSA.FetchData();
                    _reservationJoineds = reservationSA.GetData().Cast<ReservationJoined>();
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }
        }
        /// <summary>
        /// Processes the data retrieved from the database by filtering based on <see cref="Target"/>, 
        /// and converts the result into an <see cref="ObservableCollection{ReservationJoinedObservable}"/>
        /// and sets <see cref="ReservationJoinedsObservable"/> to the result.
        /// </summary>
        public void ProcessData()
        {
            try
            {
                if (_reservationJoineds.IsNullOrEmpty())
                {
                    throw new Exception("Data tidak ditemukan");
                }
                if (!_target.IsNullOrEmpty())
                {
                    _reservationJoineds = _reservationJoineds.Where(x => x.Reservation.ReservationCode == _target);
                }

                ReservationJoinedsObservable.Clear();

                foreach (var item in _reservationJoineds)
                {
                    ReservationJoinedsObservable.Add(new ReservationJoinedObservable
                    {
                        Customer = DataObservableConverter.FromCustomerEntity(item.Customer),
                        Room = DataObservableConverter.FromRoomEntity(item.Room),
                        Reservation = DataObservableConverter.FromReservationEntity(item.Reservation)
                    });
                }

                Target = string.Empty;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        #endregion
    }
}
