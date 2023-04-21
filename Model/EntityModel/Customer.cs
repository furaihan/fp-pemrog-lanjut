namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Represents customer data in the database.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _nik = string.Empty;
            _phoneNumber = string.Empty;
            _email = string.Empty;
        }

        private int _customerID;
        private string _firstName;
        private string _lastName;
        private string _nik;
        private string _phoneNumber;
        private string _email;

        /// <summary>
        /// Gets or sets the customer ID column in the customer table in the database.
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        /// <summary>
        /// Gets or sets the first name column in the customer table in the database.
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        /// <summary>
        /// Gets or sets the last name column in the customer table in the database.
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        /// <summary>
        /// Gets or sets the NIK column in the customer table in the database.
        /// </summary>
        public string NIK
        {
            get => _nik;
            set => _nik = value;
        }
        /// <summary>
        /// Gets or sets the phone number column in the customer table in the database.
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        /// <summary>
        /// Gets or sets the email column in the customer table in the database.
        /// </summary>
        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }
}
