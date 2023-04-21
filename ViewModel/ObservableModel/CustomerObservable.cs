namespace PinusPengger.ViewModel.ObservableModel
{
    /// <summary>
    /// Represents a customer observable in the hotel management system.
    /// </summary>
    public class CustomerObservable : ViewModelBase
    {
        private int _customerID;
        private string _firstName;
        private string _lastName;
        private string _nik;
        private string _phoneNumber;
        private string _email;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerObservable"/> class.
        /// </summary>
        public CustomerObservable()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _nik = string.Empty;
            _phoneNumber = string.Empty;
            _email = string.Empty;
        }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the full name of the customer by combining the first and last names.
        /// </summary>
        public string FullName
        {
            get => _firstName + " " + LastName;
        }

        /// <summary>
        /// Gets or sets the National ID number (NIK) of the customer.
        /// </summary>
        public string Nik
        {
            get => _nik;
            set
            {
                _nik = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the phone number of the customer.
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
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
