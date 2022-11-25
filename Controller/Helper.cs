using System;
using System.Collections.Generic;
using System.Linq;

namespace PinusPengger.Controller
{
    internal static class Helper
    {
        internal static Random Random = new();
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
            return GetRandomElement(array, shuffle);
        }

        public static T GetRandomElement<T>(this Enum items)
        {
            if (typeof(T).BaseType != typeof(Enum))
                throw new InvalidCastException();
            Array types = Enum.GetValues(typeof(T));
            return GetRandomElement(types.Cast<T>());
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
    }
}
