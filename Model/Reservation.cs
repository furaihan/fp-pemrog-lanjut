using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PinusPengger.Model
{
    public class Reservation : INotifyPropertyChanged
    {
        private int _id;
        private string _code;
        private DateTime? _checkIn;
        private DateTime? _checkOut;
        private ReservationStatus _status;
        private int _idRoom;
        private int _idCustomer;

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
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged();
            }
        }
        public DateTime? CheckIn
        {
            get => _checkIn;
            set
            {
                _checkIn = value;
                OnPropertyChanged();
            }
        }
        public DateTime? CheckOut
        {
            get => _checkOut;
            set
            {
                _checkOut = value;
                OnPropertyChanged();
            }
        }
        public ReservationStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        public int IDRoom
        {
            get => _idRoom;
            set
            {
                _idRoom = value;
                OnPropertyChanged();
            }
        }
        public int IDCustomer
        {
            get => _idCustomer;
            set
            {
                _idCustomer = value;
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
    public enum ReservationStatus
    {
        Booked = 0,
        CheckedIn = 1,
        CheckedOut = 2,
    }
}
