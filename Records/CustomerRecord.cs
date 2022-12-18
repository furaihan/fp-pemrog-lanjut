using PinusPengger.ViewModel;
using System;

namespace PinusPengger.Records
{
    /// <summary>
    /// Representasi dari record di dalam tabel pelanggan yang dapat membangkitkan event apabila ternadi perubahan data
    /// </summary>
    internal class CustomerRecord : ViewModelBase
    {
        private int? _id;
        private string _nik;
        private string _name;
        private DateOnly? _birthDate;
        private string _phone;

        public int? ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string NIK
        {
            get => _nik;
            set
            {
                _nik = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public DateOnly? BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

    }
}
