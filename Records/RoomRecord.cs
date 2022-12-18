using PinusPengger.Model;
using PinusPengger.ViewModel;

namespace PinusPengger.Records
{
    /// <summary>
    /// Representasi dari record di dalam tabel kamar yang dapat membangkitkan event apabila ternadi perubahan data
    /// </summary>
    internal class RoomRecord : ViewModelBase
    {
        private int? _id;
        private string _code;
        private short? _number;
        private short? _floor;
        private RoomType? _type;

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
        public short? Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }
        public short? Floor
        {
            get => _floor;
            set
            {
                _floor = value;
                OnPropertyChanged();
            }
        }
        public RoomType? Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }
    }
}
