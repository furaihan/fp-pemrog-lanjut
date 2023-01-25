using PinusPengger.Model.EntityModel;

namespace PinusPengger.Model.CombinedModel
{
    /// <summary>
    /// Merepresentasikan gabungan antara <see cref="EntityModel.Reservation"/> dengan <see cref="EntityModel.Customer"/> dan <see cref="EntityModel.Room"/>
    /// </summary>
    public class ReservationJoined
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="ReservationJoined"/>
        /// </summary>
        public ReservationJoined()
        {
            _customer = new Customer();
            _room = new Room();
            _reservation = new Reservation();
        }

        private Customer _customer;
        private Room _room;
        private Reservation _reservation;

        /// <summary>
        /// Merepresentasikan data seorang pelanggan yang sedang melakukan reservasi
        /// </summary>
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
        /// <summary>
        /// Merepresentasikan data kamar yang sedang dipesan oleh pelanggan 
        /// </summary>
        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        /// <summary>
        /// Merepresentasikan data reservasi pelanggan
        /// </summary>
        public Reservation Reservation
        {
            get => _reservation;
            set => _reservation = value;
        }
    }
}
