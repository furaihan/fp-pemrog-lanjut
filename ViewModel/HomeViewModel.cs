using PinusPengger.Model;
using PinusPengger.Records;
using PinusPengger.Repository;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PinusPengger.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            //_reservationEntity = new Reservation();
            _repository = new ReservationCRUD();
            _reservations = new List<Reservation>();
            ResRecEntity = new ReservationRecord();
            ReservationRecords = new ObservableCollection<ReservationRecord>();
            FetchData();
            GetData();
        }

        #region Field
        private string _target;
        private ICommand _searchCommand;
        //private Reservation _reservationEntity;
        private ReservationCRUD _repository;
        private List<Reservation> _reservations;
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
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new ViewModelCommand(param => GetData(param.ToString()));
                }
                return _searchCommand;
            }
        }
        public ReservationRecord ResRecEntity { get; set; }
        public ObservableCollection<ReservationRecord> ReservationRecords { get; set; }
        #endregion

        #region Method
        private void FetchData()
        {
            _reservations.Clear();
            _repository.ReadData().ForEach(data => _reservations.Add(data));
        }
        public void GetData(string target = null)
        {
            if (string.IsNullOrEmpty(target))
            {
                _reservations.ForEach(data => ReservationRecords.Add(
                    new ReservationRecord
                    {
                        ID = data.ResID,
                        Code = data.ResCode,
                        CheckIn = data.ResCheckIn,
                        CheckOut = data.ResCheckOut,
                        Status = data.ResStatus,
                        IDCustomer = data.ResIDCust,
                        IDRoom = data.ResIDRoom
                    }));
            }
            else
            {
                var data = _reservations.Find(data => target == data.ResCode);
                ReservationRecords.Clear();
                ReservationRecords.Add(new ReservationRecord
                {
                    ID = data.ResID,
                    Code = data.ResCode,
                    CheckIn = data.ResCheckIn,
                    CheckOut = data.ResCheckOut,
                    Status = data.ResStatus,
                    IDCustomer = data.ResIDCust,
                    IDRoom = data.ResIDRoom
                });
            }
        }
        #endregion
    }
}
