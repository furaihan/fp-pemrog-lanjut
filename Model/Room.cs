using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PinusPengger.Model
{
    public class Room : INotifyPropertyChanged
    {
        private RoomNumbering roomNumber;
        private RoomType type;
        private RoomFeature feature;
        public Room(RoomNumbering roomNumber, RoomType type, RoomFeature feature)
        {
            RoomNumber = roomNumber;
            Type = type;
            Feature = feature;
        }

        [Key]
        public RoomNumbering RoomNumber
        {
            get => roomNumber;
            set
            {
                roomNumber = value;
                OnPropertyChanged();
            }
        }
        public RoomType Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }
        public RoomFeature Feature
        {
            get => feature;
            set
            {
                feature = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public struct RoomNumbering : IEquatable<RoomNumbering>
    {
        public byte Floor;
        public byte RoomNumber;
        public RoomNumbering(byte floor, byte number)
        {
            Floor = floor;
            RoomNumber = number;
        }

        public bool Equals(RoomNumbering other)
        {
            return other.Floor == this.Floor && other.RoomNumber == this.RoomNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is RoomNumbering room && Equals(room);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Floor, RoomNumber);
        }

        public static bool operator ==(RoomNumbering left, RoomNumbering right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RoomNumbering left, RoomNumbering right)
        {
            return !(left == right);
        }
    }
    [Flags]
    public enum RoomFeature : uint
    {
        DoubleBed = 1 << 0,
        SingleBed = 1 << 1,
        Heater = 1 << 2,
    }
    public enum RoomType
    {
        Reguler = 0,
        VIP = 1,
        VVIP = 2,
    }

}
