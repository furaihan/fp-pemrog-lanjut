using System;
using System.Collections.Generic;

namespace PinusPengger.ViewModel
{
    public static class Mediator
    {
        private static IDictionary<string, List<Action<object>>> _callbackList = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// Register callback methods
        /// </summary>
        /// <param name="token"></param>
        /// <param name="callback"></param>
        public static void Register(string token, Action<object> callback)
        {
            if (!_callbackList.ContainsKey(token))
            {
                _callbackList[token] = new List<Action<object>>();
            }
            _callbackList[token].Add(callback);
        }
        /// <summary>
        /// Unregister callback methods
        /// </summary>
        /// <param name="token"></param>
        /// <param name="callback"></param>
        public static void Unregister(string token, Action<object> callback)
        {
            if (_callbackList.ContainsKey(token))
            {
                _callbackList[token].Remove(callback);
            }
        }
        /// <summary>
        /// Pass arguments and call the methods based on token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="args"></param>
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
