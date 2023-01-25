using PinusPengger.Model.CombinedModel;
using PinusPengger.Model.DataAccessLayer;
using PinusPengger.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PinusPengger.Model.ServiceAgent
{
    /// <summary>
    /// Layanan mengakses model <see cref="CombinedModel.RoomWithFacilities"/>
    /// </summary>
    public class RoomSA : ServiceAgent, IDisposable
    {
        /// <summary>
        /// Menginisialisasi objek <see cref="RoomSA"/>
        /// </summary>
        public RoomSA()
        {
            _roomDAL = new RoomDAL();
            _roomFacilityDAL = new RoomFacilityDAL();
            _roomFacilityBathroomDAL = new RoomFacilityBathroomDAL();
            _roomFacilityOtherDAL = new RoomFacilityOtherDAL();
            _rooms = new List<Room>();
            _roomFacilities = new List<RoomFacility>();
            _roomFacilityBathrooms = new List<RoomFacilityBathroom>();
            _roomFacilityOthers = new List<RoomFacilityOther>();
        }

        private RoomDAL _roomDAL;
        private RoomFacilityDAL _roomFacilityDAL;
        private RoomFacilityBathroomDAL _roomFacilityBathroomDAL;
        private RoomFacilityOtherDAL _roomFacilityOtherDAL;
        private List<Room> _rooms;
        private List<RoomFacility> _roomFacilities;
        private List<RoomFacilityBathroom> _roomFacilityBathrooms;
        private List<RoomFacilityOther> _roomFacilityOthers;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void FetchData()
        {
            // Fetch room datas
            _rooms = _roomDAL.ReadData().Cast<Room>().ToList();

            // Fetch basic room facility datas
            _roomFacilities = _roomFacilityDAL.ReadData().Cast<RoomFacility>().ToList();

            // Fetch room bathroom facility datas
            _roomFacilityBathrooms = _roomFacilityBathroomDAL.ReadData().Cast<RoomFacilityBathroom>().ToList();

            // Fetch room other facility datas
            _roomFacilityOthers = _roomFacilityOtherDAL.ReadData().Cast<RoomFacilityOther>().ToList();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override IEnumerable<object> GetData()
        {
            FetchData();

            var result = from room in _rooms
                         join roomFacility in _roomFacilities on room.RoomType equals roomFacility.RoomType
                         select new RoomWithFacilities
                         {
                             Room = room,
                             RoomFacility = roomFacility,
                             RoomFacilityBathrooms = _roomFacilityBathrooms.Where(data => data.RoomType == roomFacility.RoomType).ToList(),
                             RoomFacilityOthers = _roomFacilityOthers.Where(data => data.RoomType == roomFacility.RoomType).ToList()
                         };
            Debug.WriteLine($"RoomSA GetData Count: {result.Count()}");
            return result;
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            _roomDAL.Dispose();
            _roomFacilityDAL.Dispose();
            _roomFacilityBathroomDAL.Dispose();
            _roomFacilityOtherDAL.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
