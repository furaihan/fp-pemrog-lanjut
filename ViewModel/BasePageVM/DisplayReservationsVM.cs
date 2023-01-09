using Microsoft.IdentityModel.Tokens;
using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.ServiceAgent;
using PinusPengger.ViewModel.Helper;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayReservationsVM : ViewModelBase, IBasePage
    {
        public DisplayReservationsVM()
        {
            _target = string.Empty;
            _errorMessage = string.Empty;
            _searchCommand = new ViewModelCommand(param => ProcessData());
            _reservationJoineds = Enumerable.Empty<ReservationJoined>();
            ReservationJoinedsObservable = new ObservableCollection<ReservationJoinedObservable>();
            GetData();
            ProcessData();
        }

        #region Field
        private string _target;
        private string _errorMessage;
        private ViewModelCommand _searchCommand;
        private IEnumerable<ReservationJoined> _reservationJoineds;
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
        public ObservableCollection<ReservationJoinedObservable> ReservationJoinedsObservable { get; set; }
        #endregion

        #region Method
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
