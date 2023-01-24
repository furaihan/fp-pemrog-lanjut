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
            _roomWithFacilitiesObservable = new ObservableCollection<RoomWithFacilitiesObservable>();
            SelectedOption = Tag.RoomType.REG;
            Options = new List<Tag.RoomType>() { Tag.RoomType.REG, Tag.RoomType.VIP };
            RoomWithFacilitiesObservable = new ObservableCollection<RoomWithFacilitiesObservable>();
            _roomPool = new List<RoomWithFacilitiesObservable>();
            PropertyChanged += OnSelectedOptionChanged;
            GetData();
            ProcessData();
        }

        #region Field
        private Tag.RoomType _selectedOption;
        private string _errorMessage;
        private IEnumerable<RoomWithFacilities> _roomWithFacilities;
        private List<RoomWithFacilitiesObservable> _roomPool;
        private ICommand _roomButtonCommand;
        private ObservableCollection<RoomWithFacilitiesObservable> _roomWithFacilitiesObservable;
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
        public ObservableCollection<RoomWithFacilitiesObservable> RoomWithFacilitiesObservable
        {
            get => _roomWithFacilitiesObservable;
            set
            {
                _roomWithFacilitiesObservable = value;
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
            if (parameter is not RoomWithFacilities) return;
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
                    foreach (var item in _roomWithFacilities)
                    {
                        _roomPool.Add(new RoomWithFacilitiesObservable
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

                //var temp = _roomWithFacilities.Where(x => x.Room.RoomType == _selectedOption);
                RoomWithFacilitiesObservable.Clear();
                RoomWithFacilitiesObservable = new ObservableCollection<RoomWithFacilitiesObservable>(_roomPool.Where(x => x.Room.RoomType == _selectedOption));
                /*foreach (var item in temp)
                {
                    RoomWithFacilitiesObservable.Add(new RoomWithFacilitiesObservable
                    {
                        Room = DataObservableConverter.FromRoomEntity(item.Room),
                        RoomFacility = DataObservableConverter.FromRoomFacilityEntity(item.RoomFacility),
                        RoomFacilityBathrooms = DataObservableConverter.FromRoomFacilityBathroomEntities(item.RoomFacilityBathrooms),
                        RoomFacilityOthers = DataObservableConverter.FromRoomFacilityOtherEntities(item.RoomFacilityOthers)
                    });
                }*/
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        #endregion
    }
}
