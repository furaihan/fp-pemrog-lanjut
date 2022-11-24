using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinusPengger.Model
{
    class Reservation
    {
        public int KodePemesanan { get; set; }
        public Room Room { get; set; }
        public Person Person { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
