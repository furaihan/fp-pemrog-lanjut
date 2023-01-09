using PinusPengger.Model.EntityModel;
using PinusPengger.ViewModel.ObservableModel;
using System.Collections.Generic;

namespace PinusPengger.ViewModel.Helper
{
    public static class DataObservableConverter
    {
        public static CustomerObservable FromCustomerEntity(Customer customer)
        {
            CustomerObservable result = new CustomerObservable()
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
        public static ReservationObservable FromReservationEntity(Reservation reservation)
        {
            ReservationObservable result = new ReservationObservable()
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
        public static HistoryObservable FromHistoryEntity(History history)
        {
            HistoryObservable result = new HistoryObservable()
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
        public static RoomObservable FromRoomEntity(Room room)
        {
            RoomObservable result = new RoomObservable()
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
        public static RoomFacilityObservable FromRoomFacilityEntity(RoomFacility roomFacility)
        {
            RoomFacilityObservable result = new RoomFacilityObservable()
            {
                RoomType = roomFacility.RoomType,
                Bed = roomFacility.Bed,
                Internet = roomFacility.Internet
            };

            return result;
        }
        public static List<RoomFacilityBathroomObservable> FromRoomFacilityBathroomEntities(List<RoomFacilityBathroom> roomFacilityBathrooms)
        {
            List<RoomFacilityBathroomObservable> roomFacilityBathroomObservables = new List<RoomFacilityBathroomObservable>();

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
        public static List<RoomFacilityOtherObservable> FromRoomFacilityOtherEntities(List<RoomFacilityOther> roomFacilityOthers)
        {
            List<RoomFacilityOtherObservable> roomFacilityOtherObservables = new List<RoomFacilityOtherObservable>();

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
        /*
         * internal static Random Random = new();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                int k = Random.Next(n--);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
        public static T GetRandomElement<T>(this IList<T> list, bool shuffle = false)
        {
            if (list == null || list.Count <= 0)
                return default;

            if (shuffle) list.Shuffle();
            return list[Random.Next(list.Count)];
        }

        public static T GetRandomElement<T>(this IEnumerable<T> enumarable, bool shuffle = false)
        {
            if (enumarable == null || !enumarable.Any())
                return default;

            T[] array = enumarable.ToArray();
            return array.GetRandomElement(shuffle);
        }

        public static T GetRandomElement<T>(this Enum items)
        {
            if (typeof(T).BaseType != typeof(Enum))
                throw new InvalidCastException();
            Array types = Enum.GetValues(typeof(T));
            return types.Cast<T>().GetRandomElement();
        }
        public static T GetRandomElement<T>(this IEnumerable<T> items, Predicate<T> predicate, bool shuffle = false)
        {
            List<T> sorted = items.ToList().FindAll(predicate);
            return sorted.GetRandomElement(shuffle);
        }

        public static IList<T> GetRandomNumberOfElements<T>(this IList<T> list, int numOfElements, bool shuffle = false)
        {
            List<T> givenList = new(list);
            List<T> l = new();
            for (int i = 0; i < numOfElements; i++)
            {
                T t = givenList.GetRandomElement(shuffle);
                givenList.Remove(t);
                l.Add(t);
            }
            return l;
        }

        public static IEnumerable<T> GetRandomNumberOfElements<T>(this IEnumerable<T> enumarable, int numOfElements, bool shuffle = false)
        {
            List<T> givenList = new(enumarable);
            List<T> l = new();
            for (int i = 0; i < numOfElements; i++)
            {
                T t = givenList.Except(l).GetRandomElement(shuffle);
                l.Add(t);
            }
            return l;
        }
         * */
    }
}
