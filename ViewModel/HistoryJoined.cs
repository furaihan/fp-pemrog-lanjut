using PinusPengger.Model;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// Representasi dari join tabel
    /// </summary>
    class HistoryJoined : ViewModelBase
    {
        private History _historyEntity;
        private Customer _customerEntity;
        private Room _roomEntity;

        public History HistoryEntity
        {
            get => _historyEntity;
            set
            {
                _historyEntity = value;
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
