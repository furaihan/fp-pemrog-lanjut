﻿using PinusPengger.Model;

namespace PinusPengger.ViewModel.Extension
{
    class ReservationJoined : ViewModelBase
    {
        private Reservation _reservationEntity;
        private Customer _customerEntity;
        private Room _roomEntity;

        public Reservation HistoryEntity
        {
            get => _reservationEntity;
            set
            {
                _reservationEntity = value;
                OnPropertyChanged();
            }
        }
        public Customer CustomerEntity
        {
            get => _customerEntity;
            set
            {
                _customerEntity = value;
                OnPropertyChanged();
            }
        }
        public Room RoomEntity
        {
            get => _roomEntity;
            set
            {
                _roomEntity = value;
                OnPropertyChanged();
            }
        }
    }
}
