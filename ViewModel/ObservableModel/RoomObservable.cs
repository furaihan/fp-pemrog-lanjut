﻿using PinusPengger.Model;
using PinusPengger.Model.EntityModel;

namespace PinusPengger.ViewModel.ObservableModel
{
    public class RoomObservable : ViewModelBase
    {
        private int _roomID;
        private string _roomCode;
        private byte _roomFloor;
        private byte _roomNumber;
        private byte _squareMeter;
        Tag.RoomType _roomType;

        public RoomObservable()
        {
            _roomCode = string.Empty;
        }

        public int RoomID
        {
            get => _roomID;
            set
            {
                _roomID = value;
                OnPropertyChanged();
            }
        }
        public string RoomCode
        {
            get => _roomCode;
            set
            {
                _roomCode = value;
                OnPropertyChanged();
            }
        }
        public byte RoomFloor
        {
            get => _roomFloor;
            set
            {
                _roomFloor = value;
                OnPropertyChanged();
            }
        }
        public byte RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
            }
        }
        public byte SquareMeter
        {
            get => _squareMeter;
            set
            {
                _squareMeter = value;
                OnPropertyChanged();
            }
        }
        internal Tag.RoomType RoomType
        {
            get => _roomType;
            set
            {
                _roomType = value;
                OnPropertyChanged();
            }
        }
        internal static RoomObservable FromEntity(Room room)
        {
            return new RoomObservable()
            {
                RoomID = room.RoomID,
                RoomCode = room.RoomCode,
                RoomFloor = room.RoomFloor,
                RoomNumber = room.RoomNumber,
                SquareMeter = room.SquareMeter,
                RoomType = room.RoomType
            };
        }
    }
}
