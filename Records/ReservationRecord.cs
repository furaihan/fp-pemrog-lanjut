using PinusPengger.Model;
using PinusPengger.ViewModel;
using System;

namespace PinusPengger.Records
{
    internal class ReservationRecord : ViewModelBase
    {
        private int? _id;
        private string _code;
        private DateTime? _checkIn;
        private DateTime? _checkOut;
        private ReservationStatus? _status;
        private int? _idCustomer;
        private int? _idRoom;

        public int? ID
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
        public ReservationStatus? Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        public int? IDCustomer
        {
            get => _idCustomer;
            set
            {
                _idCustomer = value;
                OnPropertyChanged();
            }
        }
        public int? IDRoom
        {
            get => _idRoom;
            set
            {
                _idRoom = value;
                OnPropertyChanged();
            }
        }
    }
}
