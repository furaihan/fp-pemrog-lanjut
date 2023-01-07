namespace PinusPengger.Model.EntityModel
{
    /// <summary>
    /// Merepresentasikan data seorang pelanggan di database
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="Customer"/>
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
        /// Merepresentasikan kolom id pelanggan pada tabel pelanggan di database
        /// </summary>
        public int CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        /// <summary>
        /// Merepresentasikan kolom nama awal pada tabel pelanggan di database
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        /// <summary>
        /// Merepresentasikan kolom nama akhir pada tabel pelanggan di database
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        /// <summary>
        /// Merepresentasikan kolom NIK pada tabel pelanggan di database
        /// </summary>
        public string NIK
        {
            get => _nik;
            set => _nik = value;
        }
        /// <summary>
        /// Merepresentasikan kolom nomor telepon pada tabel pelanggan di database
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }
        /// <summary>
        /// Merepresentasikan kolom email pada tabel pelanggan di database
        /// </summary>
        public string Email
        {
            get => _email;
            set => _email = value;
        }
    }
}
