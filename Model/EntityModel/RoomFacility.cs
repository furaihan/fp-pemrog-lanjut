namespace TestingDatabase.Model.EntityModel
{
    internal class RoomFacility
    {
        public RoomFacility()
        {
            _bed = string.Empty;
            _internet = string.Empty;
        }

        private Tag.RoomType _roomType;
        private string _bed;
        private string _internet;

        public Tag.RoomType RoomType
        {
            get => _roomType;
            set => _roomType = value;
        }
        public string Bed
        {
            get => _bed;
            set => _bed = value;
        }
        public string Internet
        {
            get => _internet;
            set => _internet = value;
        }
    }
}
