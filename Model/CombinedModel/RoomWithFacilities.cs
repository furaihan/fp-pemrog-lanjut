using TestingDatabase.Model.EntityModel;

namespace TestingDatabase.Model.CombinedModel
{
    internal class RoomWithFacilities
    {
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

        public Room Room
        {
            get => _room;
            set => _room = value;
        }
        public RoomFacility RoomFacility
        {
            get => _roomFacility;
            set => _roomFacility = value;
        }
        public List<RoomFacilityBathroom> RoomFacilityBathrooms
        {
            get => _roomFacilityBathrooms;
            set => _roomFacilityBathrooms = value;
        }
        public List<RoomFacilityOther> RoomFacilityOthers
        {
            get => _roomFacilityOthers;
            set => _roomFacilityOthers = value;
        }
    }
}
