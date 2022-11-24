using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinusPengger.Model
{
    [Flags]
    public enum RoomFeature : uint
    {
        DoubleBed = 1 << 0,
        SingleBed = 1 << 1,
        Heater = 1 << 2,
    }
    public class Room
    {
        public int RoomId { get; set; }
    }
}
