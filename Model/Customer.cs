using System;

namespace PinusPengger.Model
{
    internal class Customer
    {
        public int? CustID { get; set; }
        public string CustNIK { get; set; }
        public string CustName { get; set; }
        public DateOnly? CustBirthDate { get; set; }
        public string CustPhone { get; set; }
    }
}
