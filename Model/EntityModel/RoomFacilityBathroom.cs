namespace TestingDatabase.Model.EntityModel
{
    internal class RoomFacilityBathroom
    {
        public RoomFacilityBathroom()
        {
            _nameOfFacility = string.Empty;
        }

        private string _nameOfFacility;
        private Tag.RoomType _roomType;

        public string NameOfFacility
        {
            get => _nameOfFacility;
            set => _nameOfFacility = value;
        }
        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
    }
}
