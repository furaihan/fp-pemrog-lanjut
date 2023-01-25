using System;
using System.Collections.Generic;

namespace PinusPengger.ViewModel
{
    public static class Mediator
    {
        private static IDictionary<string, List<Action<object>>> _callbackList = new Dictionary<string, List<Action<object>>>();
        public static void Register(string token, Action<object> callback)
        {
            if (!_callbackList.ContainsKey(token))
            {
                _callbackList[token] = new List<Action<object>>();
            }
            _callbackList[token].Add(callback);
        }
        public static void Unregister(string token, Action<object> callback)
        {
            if (_callbackList.ContainsKey(token))
            {
                _callbackList[token].Remove(callback);
            }
        }
        public static void NotifyColleagues(string token, object args)
        {
            if (_callbackList.ContainsKey(token))
            {
                List<Action<object>> list = _callbackList[token];
                foreach (var callback in list)
                {
                    callback(args);
                }
            }
        }
    }
}
