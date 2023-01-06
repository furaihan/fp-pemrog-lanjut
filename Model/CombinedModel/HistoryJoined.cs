using PinusPengger.Model.EntityModel;

namespace PinusPengger.Model.CombinedModel
{
    /// <summary>
    /// Merepresentasikan gabungan antara <see cref="EntityModel.History"/> dengan <see cref="EntityModel.Customer"/> dan <see cref="EntityModel.Room"/>
    /// </summary>
    internal class HistoryJoined
    {
        /// <summary>
        /// Menginisiasi objek <see cref="HistoryJoined"/>
        /// </summary>
        public HistoryJoined()
        {
            _customer = new Customer();
            _room = new Room();
            _history = new History();
        }

        private Customer _customer;
        private Room _room;
        private History _history;

        /// <summary>
        /// Merepresentasikan data seorang pelanggan yang telah melakukan checkout
        /// </summary>
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
        /// <summary>
        /// Merepresentasikan data kamar yang dipesan pelanggan
        /// </summary>
        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        /// <summary>
        /// Merepresentasikan data riwayat reservasi pelanggan
        /// </summary>
        public History History
        {
            get => _history;
            set => _history = value;
        }
    }
}
