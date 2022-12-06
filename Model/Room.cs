﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PinusPengger.Model
{
    public class Room : INotifyPropertyChanged
    {
        // private RoomNumbering roomNumber;
        private int _id;
        private string _code;
        private Int16 _number;
        private Int16 _floor;
        private RoomType _type;

        public int ID 
        { 
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Code 
        {
            //get => $"{_type.ToString().ToUpper()[0]}.{_floor}.{_number}";
            get => _code;
            set 
            {
                _code = value;
                OnPropertyChanged();
            }
        }
        public Int16 Number
        { 
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }
        public Int16 Floor 
        { 
            get => _floor;
            set
            {
                _floor = value;
                OnPropertyChanged();
            }
        }
        public RoomType Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    [Flags]
    public enum RoomType
    {
        Reguler = 0,
        VIP = 1
    }

}
