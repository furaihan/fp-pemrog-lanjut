namespace PinusPengger.Model
{
    /// <summary>
    /// Representasi dari record di dalam tabel kamar
    /// </summary>
    internal class Room
    {
        public int? RoomID { get; set; }
        public string RoomCode { get; set; }
        public short? RoomNumber { get; set; }
        public short? RoomFloor { get; set; }
        public RoomType? RoomType { get; set; }
    }

    /// <summary>
    /// Representasi dari kolom tipe kamar
    /// </summary>
    enum RoomType
    {
        Reg = 0,
        VIP = 1
    }
}
