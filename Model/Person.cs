using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PinusPengger.Model
{
    public class Person : INotifyPropertyChanged
    {
        private ulong nIK;
        private string name;
        private string phoneNumber;
        private DateTime? birthDate;

        public Person(ulong nIK, string name, string phoneNumber, DateTime? birthDate)
        {
            NIK = nIK;
            Name = name;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
        }

        public ulong NIK
        {
            get => nIK;
            set
            {
                nIK = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber 
        { 
            get => phoneNumber; 
            set 
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public DateTime? BirthDate 
        { 
            get => birthDate; 
            set 
            {
                birthDate = value;
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
