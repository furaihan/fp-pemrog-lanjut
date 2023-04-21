using PinusPengger.Model.EntityModel;
using PinusPengger.ViewModel.ObservableModel;
using System.Collections.Generic;

namespace PinusPengger.ViewModel.Helper
{
    /// <summary>
    /// A static class that provides methods to convert between entity model objects and observable model objects.
    /// </summary>
    public static class DataObservableConverter
    {
        /// <summary>
        /// Converts a <see cref="Customer"/> entity object into a <see cref="CustomerObservable"/> observable object.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> entity object to convert.</param>
        /// <returns>The converted <see cref="CustomerObservable"/> observable object.</returns>
        public static CustomerObservable FromCustomerEntity(Customer customer)
        {
            CustomerObservable result = new()
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Nik = customer.NIK,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email
            };

            return result;
        }
        /// <summary>
        /// Converts a <see cref="Reservation"/> entity object into a <see cref="ReservationObservable"/> observable object.
        /// </summary>
        /// <param name="reservation">The <see cref="Reservation"/> entity object to convert.</param>
        /// <returns>The converted <see cref="ReservationObservable"/> observable object.</returns>
        public static ReservationObservable FromReservationEntity(Reservation reservation)
        {
            ReservationObservable result = new()
            {
                ReservationID = reservation.ReservationID,
                ReservationCode = reservation.ReservationCode,
                NumberOfGuests = reservation.NumberOfGuests,
                Checkin = reservation.Checkin,
                Checkout = reservation.Checkout,
                ReservationStatus = reservation.ReservationStatus,
                CustomerID = reservation.CustomerID,
                RoomID = reservation.RoomID
            };

            return result;
        }
        /// <summary>
        /// Converts a <see cref="History"/> entity object into a <see cref="HistoryObservable"/> observable object.
        /// </summary>
        /// <param name="history">The <see cref="History"/> entity object to convert.</param>
        /// <returns>The converted <see cref="HistoryObservable"/> observable object.</returns>
        public static HistoryObservable FromHistoryEntity(History history)
        {
            HistoryObservable result = new()
            {
                HistoryID = history.HistoryID,
                ReservationCode = history.ReservationCode,
                NumberOfGuests = history.NumberOfGuests,
                Checkin = history.Checkin,
                Checkout = history.Checkout,
                CustomerID = history.CustomerID,
                RoomID = history.RoomID
            };

            return result;
        }
        /// <summary>
        /// Converts a <see cref="Room"/> entity object into a <see cref="RoomObservable"/> observable object.
        /// </summary>
        /// <param name="room">The <see cref="Room"/> entity object to convert.</param>
        /// <returns>The converted <see cref="RoomObservable"/> observable object.</returns>
        public static RoomObservable FromRoomEntity(Room room)
        {
            RoomObservable result = new()
            {
                RoomID = room.RoomID,
                RoomCode = room.RoomCode,
                RoomFloor = room.RoomFloor,
                RoomNumber = room.RoomNumber,
                SquareMeter = room.SquareMeter,
                RoomType = room.RoomType
            };

            return result;
        }
        /// <summary>
        /// Converts a <see cref="Room"/> entity object into a <see cref="RoomObservable"/> observable object.
        /// </summary>
        /// <param name="room">The <see cref="Room"/> entity object to convert.</param>
        /// <returns>The converted <see cref="RoomObservable"/> observable object.</returns>
        public static RoomFacilityObservable FromRoomFacilityEntity(RoomFacility roomFacility)
        {
            RoomFacilityObservable result = new()
            {
                RoomType = roomFacility.RoomType,
                Bed = roomFacility.Bed,
                Internet = roomFacility.Internet
            };

            return result;
        }
        /// <summary>
        /// Converts a list of <see cref="RoomFacilityBathroom"/> entity objects into a list of <see cref="RoomFacilityBathroomObservable"/> observable objects.
        /// </summary>
        /// <param name="roomFacilityBathrooms">The list of <see cref="RoomFacilityBathroom"/> entity objects to convert.</param>
        /// <returns>The converted list of <see cref="RoomFacilityBathroomObservable"/> observable objects.</returns>
        public static List<RoomFacilityBathroomObservable> FromRoomFacilityBathroomEntities(List<RoomFacilityBathroom> roomFacilityBathrooms)
        {
            List<RoomFacilityBathroomObservable> roomFacilityBathroomObservables = new();

            foreach (var item in roomFacilityBathrooms)
            {
                roomFacilityBathroomObservables.Add(new RoomFacilityBathroomObservable
                {
                    NameOfFacility = item.NameOfFacility,
                    RoomType = item.RoomType
                });
            }

            return roomFacilityBathroomObservables;
        }
        /// <summary>
        /// Converts a list of <see cref="RoomFacilityOther"/> entity objects into a list of <see cref="RoomFacilityOtherObservable"/> observable objects.
        /// </summary>
        /// <param name="roomFacilityOthers">The list of <see cref="RoomFacilityOther"/> entity objects to convert.</param>
        /// <returns>The converted list of <see cref="RoomFacilityOtherObservable"/> observable objects.</returns>
        public static List<RoomFacilityOtherObservable> FromRoomFacilityOtherEntities(List<RoomFacilityOther> roomFacilityOthers)
        {
            List<RoomFacilityOtherObservable> roomFacilityOtherObservables = new();

            foreach (var item in roomFacilityOthers)
            {
                roomFacilityOtherObservables.Add(new RoomFacilityOtherObservable
                {
                    NameOfFacility = item.NameOfFacility,
                    RoomType = item.RoomType
                });
            }

            return roomFacilityOtherObservables;
        }       
    }
}
