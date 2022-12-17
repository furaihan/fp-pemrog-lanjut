using System;

namespace PinusPengger.Model
{
    /// <summary>
    /// Representasi dari record di dalam tabel pelanggan
    /// </summary>
    internal class Customer
    {
        public int? CustID { get; set; }
        public string CustNIK { get; set; }
        public string CustName { get; set; }
        public DateOnly? CustBirthDate { get; set; }
        public string CustPhone { get; set; }
    }
}
