using Microsoft.IdentityModel.Tokens;
using PinusPengger.Model;
using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.ServiceAgent;
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
            _errorMessage = string.Empty;
            _roomWithFacilities = Enumerable.Empty<RoomWithFacilities>();
            Options = new List<Tag.RoomType>() { Tag.RoomType.REG, Tag.RoomType.VIP };
            RoomWithFacilitiesObservable = new List<RoomWithFacilitiesObservable>();
            RoomWithFacilities = new ObservableCollection<RoomWithFacilities>();
            PropertyChanged += OnSelectedOptionChanged;
            GetData();
        }

        #region Field
        private Tag.RoomType _selectedOption;
        private string _errorMessage;
        private IEnumerable<RoomWithFacilities> _roomWithFacilities;
        private ObservableCollection<RoomWithFacilities> roomWithFacilities;
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
        public List<RoomWithFacilitiesObservable> RoomWithFacilitiesObservable { get; set; }
        public ObservableCollection<RoomWithFacilities> RoomWithFacilities
        {
            get => roomWithFacilities;
            set
            {
                roomWithFacilities = value;
                OnPropertyChanged();
            }
        }

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
            if (parameter is not Model.CombinedModel.RoomWithFacilities) return;
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
            using (var roomSA = new RoomSA())
            {
                try
                {
                    roomSA.FetchData();
                    _roomWithFacilities = roomSA.GetData().Cast<RoomWithFacilities>();
                    Debug.WriteLine($"RoomVM GetData Count: {_roomWithFacilities.Count()}");
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
                if (_roomWithFacilities.IsNullOrEmpty())
                {
                    throw new Exception("Data tidak ditemukan");
                }

                var temp = _roomWithFacilities.Where(x => x.Room.RoomType == _selectedOption);
                Debug.WriteLine($"Room Count: {temp.Count()}");
                RoomWithFacilitiesObservable.Clear();
                RoomWithFacilities.Clear();
                RoomWithFacilities = new ObservableCollection<RoomWithFacilities>(temp);

                foreach (var item in temp)
                {
                    RoomWithFacilitiesObservable.Add(new RoomWithFacilitiesObservable
                    {
                        Room = DataObservableConverter.FromRoomEntity(item.Room),
                        RoomFacility = DataObservableConverter.FromRoomFacilityEntity(item.RoomFacility),
                        RoomFacilityBathrooms = DataObservableConverter.FromRoomFacilityBathroomEntities(item.RoomFacilityBathrooms),
                        RoomFacilityOthers = DataObservableConverter.FromRoomFacilityOtherEntities(item.RoomFacilityOthers)
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
