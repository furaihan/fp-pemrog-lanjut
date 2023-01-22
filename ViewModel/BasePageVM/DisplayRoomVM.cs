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
using System.Linq;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayRoomVM : ViewModelBase, IBasePage
    {
        public DisplayRoomVM()
        {
            GetData();
            _errorMessage = string.Empty;
            _roomWithFacilities = Enumerable.Empty<RoomWithFacilities>();
            Options = new ObservableCollection<Tag.RoomType>() { Tag.RoomType.REG, Tag.RoomType.VIP };
            RoomWithFacilitiesObservable = new ObservableCollection<RoomWithFacilitiesObservable>();
            PropertyChanged += OnSelectedOptionChanged;
        }

        #region Field
        private Tag.RoomType _selectedOption;
        private string _errorMessage;
        private IEnumerable<RoomWithFacilities> _roomWithFacilities;
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
        public ObservableCollection<Tag.RoomType> Options { get; set; }
        public ObservableCollection<RoomWithFacilitiesObservable> RoomWithFacilitiesObservable { get; set; }
        #endregion

        #region Method
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
                if (_roomWithFacilities.IsNullOrEmpty())
                {
                    throw new Exception("Data tidak ditemukan");
                }

                var temp = _roomWithFacilities.Where(x => x.Room.RoomType == _selectedOption);

                RoomWithFacilitiesObservable.Clear();

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
