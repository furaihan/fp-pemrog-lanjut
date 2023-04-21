using PinusPengger.Model.EntityModel;
using System.Collections.Generic;

namespace PinusPengger.Model.CombinedModel
{
    /// <summary>
    /// Represents a room along with its facilities
    /// </summary>
    public class RoomWithFacilities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomWithFacilities"/> class
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
        /// Gets or sets the room data
        /// </summary>
        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        /// <summary>
        /// Gets or sets the room facility data
        /// </summary>
        public RoomFacility RoomFacility
        {
            get => _roomFacility;
            set => _roomFacility = value;
        }
        /// <summary>
        /// Gets or sets the bathroom facility data
        /// </summary>
        public List<RoomFacilityBathroom> RoomFacilityBathrooms
        {
            get => _roomFacilityBathrooms;
            set => _roomFacilityBathrooms = value;
        }
        /// <summary>
        /// Gets or sets other facilities data
        /// </summary>
        public List<RoomFacilityOther> RoomFacilityOthers
        {
            get => _roomFacilityOthers;
            set => _roomFacilityOthers = value;
        }
    }
}
