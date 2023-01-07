using PinusPengger.Model.EntityModel;
using System.Collections.Generic;

namespace PinusPengger.Model.CombinedModel
{
    /// <summary>
    /// Merepresentasikan kamar beserta fasilitas lengkapnya
    /// </summary>
    public class RoomWithFacilities
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="RoomWithFacilities"/>
        /// </summary>
        public RoomWithFacilities()
        {
            _room = new Room();
            _roomFacility = new RoomFacility();
            _roomFacilityBathrooms = new List<RoomFacilityBathroom>();
            _roomFacilityOthers = new List<RoomFacilityOther>();
        }

        private Room _room;
        private RoomFacility _roomFacility;
        private List<RoomFacilityBathroom> _roomFacilityBathrooms;
        private List<RoomFacilityOther> _roomFacilityOthers;

        /// <summary>
        /// Merepresentasikan data sebuah ruangan
        /// </summary>
        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        /// <summary>
        /// Merepresentasikan data fasilitas kamar
        /// </summary>
        public RoomFacility RoomFacility
        {
            get => _roomFacility;
            set => _roomFacility = value;
        }
        /// <summary>
        /// Merepresentasikan data fasilitas kamar mandi
        /// </summary>
        public List<RoomFacilityBathroom> RoomFacilityBathrooms
        {
            get => _roomFacilityBathrooms;
            set => _roomFacilityBathrooms = value;
        }
        /// <summary>
        /// Merepresentasikan data fasilitas lainnya
        /// </summary>
        public List<RoomFacilityOther> RoomFacilityOthers
        {
            get => _roomFacilityOthers;
            set => _roomFacilityOthers = value;
        }
    }
}
