using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PinusPengger.Model
{
    public class Customer : INotifyPropertyChanged
    {
        private int _id;
        private string _nik;
        private string _name;
        private string _phoneNumber;
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
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
