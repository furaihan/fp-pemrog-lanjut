namespace TestingDatabase.Model.EntityModel
{
    internal class Customer
    {
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

        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        public string NIK
        {
            get => _nik;
            set => _nik = value;
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }
}
