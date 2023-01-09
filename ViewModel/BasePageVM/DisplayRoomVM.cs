using PinusPengger.Model;
using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.ServiceAgent;
using PinusPengger.ViewModel.Helper;
using PinusPengger.ViewModel.ObservableCombinedModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PinusPengger.ViewModel.BasePageVM
{
    public class DisplayRoomVM : ViewModelBase
    {
        public DisplayRoomVM()
        {
            Options = new ObservableCollection<Tag.RoomType>() { Tag.RoomType.REG, Tag.RoomType.VIP };
            RoomWithFacilities = new ObservableCollection<RoomWithFacilitiesObservable>();
            PropertyChanged += OnSelectedOptionChanged;
        }

        #region Field
        private Tag.RoomType _selectedOption;
        private string _errorMessage = string.Empty;
        #endregion

        #region Properties
        public Tag.RoomType SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
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
        public ObservableCollection<Tag.RoomType> Options { get; set; }
        public ObservableCollection<RoomWithFacilitiesObservable> RoomWithFacilities { get; set; }
        #endregion

        #region Method
        private void OnSelectedOptionChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedOption))
            {
                GetData();
            }
        }
        public void GetData()
        {
            using (var roomSA = new RoomSA())
            {
                try
                {
                    roomSA.FetchData();
                    var datas = roomSA.GetData(_selectedOption).ToList();

                    if (datas == null)
                    {
                        throw new Exception("Data tidak ditemukan");
                    }

                    foreach (var item in datas)
                    {
                        if (item is RoomWithFacilities itemConverted)
                        {
                            RoomWithFacilities.Add(new RoomWithFacilitiesObservable
                            {
                                Room = DataObservableConverter.FromRoomEntity(itemConverted.Room),
                                RoomFacility = DataObservableConverter.FromRoomFacilityEntity(itemConverted.RoomFacility),
                                RoomFacilityBathrooms = DataObservableConverter.FromRoomFacilityBathroomEntities(itemConverted.RoomFacilityBathrooms),
                                RoomFacilityOthers = DataObservableConverter.FromRoomFacilityOtherEntities(itemConverted.RoomFacilityOthers)
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            }
        }
        #endregion
    }
}
