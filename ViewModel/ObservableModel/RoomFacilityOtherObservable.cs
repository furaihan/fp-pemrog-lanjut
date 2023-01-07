﻿using PinusPengger.Model;

namespace PinusPengger.ViewModel.ObservableModel
{
    public class RoomFacilityOtherObservable : ViewModelBase
    {
        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        public RoomFacilityOtherObservable()
        {
            _nameOfFacility = string.Empty;
        }

        public string NameOfFacility
        {
            get => _nameOfFacility;
            set
            {
                _nameOfFacility = value;
                OnPropertyChanged();
            }
        }
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set
            {
                _roomType = value;
                OnPropertyChanged();
            }
        }
    }
}