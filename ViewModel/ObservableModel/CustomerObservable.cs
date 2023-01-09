namespace PinusPengger.ViewModel.ObservableModel
{
    public class CustomerObservable : ViewModelBase
    {
        private int _customerID;
        private string _firstName;
        private string _lastName;
        private string _nik;
        private string _phoneNumber;
        private string _email;

        public CustomerObservable()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _nik = string.Empty;
            _phoneNumber = string.Empty;
            _email = string.Empty;
        }

        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get => _firstName + " " + LastName;
        }
        public string Nik
        {
            get => _nik;
            set
            {
                _nik = value;
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
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }
}
