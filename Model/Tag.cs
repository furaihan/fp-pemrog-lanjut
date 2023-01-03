namespace TestingDatabase.Model
{
    internal static class Tag
    {
        public enum RoomType
        {
            REG,
            VIP
        }

        public enum ReservationStatus
        {
            booking,
            checkin
        }

        public enum FlushMode
        {
            add,
            update,
            delete
        }
    }
}
