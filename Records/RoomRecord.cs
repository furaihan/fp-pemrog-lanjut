using PinusPengger.ViewModel;
using System;

namespace PinusPengger.Records
{
    internal class RoomRecord : ViewModelBase
    {
        private int _id;
        private string _code;
        private short _number;
        private short _floor;
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
        public short Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }
        public short Floor
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
    }

    [Flags]
    enum RoomType
    {
        Reg = 0,
        VIP = 1
    }

}
