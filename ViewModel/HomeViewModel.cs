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
            _reservationRepo = new ReservationCRUD();
            _reservationList = new List<Reservation>();
            ReservationRecord = new ReservationRecord();
            ReservationRecords = new ObservableCollection<ReservationRecord>();
            FetchData();
            GetData();
        }

        #region Field
        private string _target;
        private ICommand _searchCommand;
        //private Reservation _reservationEntity;
        private ReservationCRUD _reservationRepo;
        private List<Reservation> _reservationList;
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
                    _searchCommand = new ViewModelCommand(GetData);
                }
                return _searchCommand;
            }
        }
        public ReservationRecord ReservationRecord { get; set; }
        public ObservableCollection<ReservationRecord> ReservationRecords { get; set; }
        #endregion

        #region Method
        private void FetchData()
        {
            _reservationList.Clear();
            _reservationRepo.ReadData().ForEach(data => _reservationList.Add(data));
        }
        public void GetData(object target = null)
        {
            if (string.IsNullOrEmpty(target.ToString()))
            {
                _reservationList.ForEach(data => ReservationRecords.Add(
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
                var data = _reservationList.Find(data => target.ToString() == data.ResCode);
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