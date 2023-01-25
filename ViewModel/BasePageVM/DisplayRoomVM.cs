using Microsoft.IdentityModel.Tokens;
using PinusPengger.Model.CombinedModel;
using PinusPengger.ServiceAgent;
using PinusPengger.View;
using PinusPengger.ViewModel.Helper;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayRoomVM : ViewModelBase, IBasePage
    {
        public DisplayRoomVM()
        {
            //_roomWithFacilities = new ObservableCollection<RoomWithFacilitiesObservable>();
            _errorMessage = string.Empty;
            SelectedOption = Tag.RoomType.REG;
            _roomPool = Enumerable.Empty<RoomWithFacilities>();
            _reservations = Enumerable.Empty<ReservationJoined>();
            Options = new List<Tag.RoomType>() { Tag.RoomType.REG, Tag.RoomType.VIP };
            RoomWithFacilitiesObservable = new ObservableCollection<RoomWithFacilitiesObservable>();
            PropertyChanged += OnSelectedOptionChanged;
            GetData();
            ProcessData();
        }

        #region Field
        //private ObservableCollection<RoomWithFacilitiesObservable> _roomWithFacilities;
        private string _errorMessage;
        private Tag.RoomType _selectedOption;
        private IEnumerable<RoomWithFacilities> _roomPool;
        private IEnumerable<ReservationJoined> _reservations;
        private ICommand _roomButtonCommand;
        #endregion

        #region Properties
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        public Tag.RoomType SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
                OnPropertyChanged();
            }
        }
        public List<Tag.RoomType> Options { get; set; }
        public ObservableCollection<RoomWithFacilitiesObservable> RoomWithFacilitiesObservable { get; set; }
        //get => _roomWithFacilities;
        //set
        //{
        //    _roomWithFacilities = value;
        //    OnPropertyChanged();
        //}
        public ICommand RoomButtonCommand
        {
            get
            {
                if (_roomButtonCommand == null)
                {
                    _roomButtonCommand = new ViewModelCommand(ExecuteRoomButtonCommand);
                }
                return _roomButtonCommand;
            }

            set => _roomButtonCommand = value;
        }
        #endregion

        #region Method
        private void ExecuteRoomButtonCommand(object parameter)
        {
            if (parameter is RoomWithFacilities obj)
            {
                var DetailRoomWindow = new DataKamarPopUp();
                Mediator.NotifyColleagues("ShowDetailRoom", obj);
                DetailRoomWindow.Show();
            }
        }
        public void OnSelectedOptionChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedOption))
            {
                ProcessData();
            }
        }
        public void GetData()
        {
            using (var reservationSA = new ReservationSA())
            {
                try
                {
                    reservationSA.FetchData();
                    _reservations = reservationSA.GetData().Cast<ReservationJoined>();
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    Debug.WriteLine(e);
                }
            }
            using (var roomSA = new RoomSA())
            {
                try
                {
                    roomSA.FetchData();
                    _roomPool = roomSA.GetData().Cast<RoomWithFacilities>();
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    Debug.WriteLine(e);
                }
            }
        }
        public void ProcessData()
        {
            try
            {
                if (_roomPool.IsNullOrEmpty())
                {
                    throw new Exception("Data tidak ditemukan");
                }

                var temp = _roomPool.Where(x => x.Room.RoomType == _selectedOption);
                RoomWithFacilitiesObservable.Clear();
                foreach (var item in temp)
                {
                    RoomWithFacilitiesObservable.Add(new RoomWithFacilitiesObservable
                    {
                        Room = DataObservableConverter.FromRoomEntity(item.Room),
                        RoomFacility = DataObservableConverter.FromRoomFacilityEntity(item.RoomFacility),
                        RoomFacilityBathrooms = DataObservableConverter.FromRoomFacilityBathroomEntities(item.RoomFacilityBathrooms),
                        RoomFacilityOthers = DataObservableConverter.FromRoomFacilityOtherEntities(item.RoomFacilityOthers),
                        IsBusy = _reservations.Any(x => x.Room.RoomCode == item.Room.RoomCode)
                    });
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        #endregion
    }
}
