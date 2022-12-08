using System;

namespace PinusPengger.Model
{
    internal class Room
    {
        public int RoomID { get; set; }
        public string RoomCode { get; set; }
        public short RoomNumber { get; set; }
        public short RoomFloor { get; set; }
        public RoomType RoomType { get; set; }
    }
    [Flags]
    enum RoomType
    {
        Reg = 0,
        VIP = 1
    }
}
