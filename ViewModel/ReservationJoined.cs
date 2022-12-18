using PinusPengger.Model;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// Representasi dari join tabel
    /// </summary>
    class ReservationJoined : ViewModelBase
    {
        private Reservation _reservationEntity;
        private Customer _customerEntity;
        private Room _roomEntity;

        public Reservation ReservationEntity
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
