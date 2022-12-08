using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PinusPengger.Model
{
    internal class Customer
    {
        public int CustID { get; set; }
        public string CustNIK { get; set; }
        public string CustName { get; set; }
        public string CustPhone { get; set; }
        public DateOnly CustBirthDate { get; set; }
    }
}
