using PinusPengger.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PinusPengger.Records
{
    internal class CustomerRecord : ViewModelBase
    {
        private int _id;
        private string _nik;
        private string _name;
        private string _phone;
        private DateOnly _birthDate;

        public int ID
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
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }
        public DateOnly BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

    }
}
