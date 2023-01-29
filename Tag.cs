namespace PinusPengger
{
    /// <summary>
    /// Kelas yang berisi penanda
    /// </summary>
    public static class Tag
    {
        /// <summary>
        /// Penanda tipe kamar
        /// </summary>
        public enum RoomType
        {
            /// <summary>
            /// Merepresentasikan tipe kamar reguler
            /// </summary>
            REG,
            /// <summary>
            /// Merepresentasikan tipe kamar VIP
            /// </summary>
            VIP
        }

        /// <summary>
        /// Penanda status reservasi
        /// </summary>
        public enum ReservationStatus
        {
            /// <summary>
            /// Merepresentasikan status reservasi booking
            /// </summary>
            booking,
            /// <summary>
            /// Merepresentasikan status reservasi checkin
            /// </summary>
            checkin
        }

        /// <summary>
        /// Penanda mode yang akan digunakan oleh 
        /// <see cref="ServiceAgent.ServiceAgent.FlushData{T}(T, object, FlushMode)"/> ketika melakukan perubahan data pada database
        /// </summary>
        public enum FlushMode
        {
            /// <summary>
            /// Mode insert, memanggil method <see cref="DataAccessLayer.IRepository.InsertRecord(object)"/>
            /// </summary>
            add,
            /// <summary>
            /// Mode update, memanggil method <see cref="DataAccessLayer.IRepository.UpdateRecord(object)"/>
            /// </summary>
            update,
            /// <summary>
            /// Mode delete, memanggil method <see cref="DataAccessLayer.IRepository.DeleteRecord(object)"/>
            /// </summary>
            delete
        }
    }
}
