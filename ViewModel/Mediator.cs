using System;
using System.Collections.Generic;

namespace PinusPengger.ViewModel
{
    /// <summary>
    /// The Mediator class is a static class that provides a simple implementation of 
    /// the mediator pattern for communication between objects.
    /// </summary>
    public static class Mediator
    {
        private static IDictionary<string, List<Action<object>>> _callbackList = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// Registers a callback method for a given token.
        /// </summary>
        /// <param name="token">The token to register the callback for.</param>
        /// <param name="callback">The callback method to be registered.</param>
        public static void Register(string token, Action<object> callback)
        {
            if (!_callbackList.ContainsKey(token))
            {
                _callbackList[token] = new List<Action<object>>();
            }
            _callbackList[token].Add(callback);
        }
        /// <summary>
        /// Unregisters a previously registered callback method for a given token.
        /// </summary>
        /// <param name="token">The token to unregister the callback for.</param>
        /// <param name="callback">The callback method to be unregistered.</param>
        public static void Unregister(string token, Action<object> callback)
        {
            if (_callbackList.ContainsKey(token))
            {
                _callbackList[token].Remove(callback);
            }
        }
        /// <summary>
        /// Notifies all registered callback methods for a given token with the provided arguments.
        /// </summary>
        /// <param name="token">The token to notify the callback methods for.</param>
        /// <param name="args">The arguments to be passed to the callback methods.</param>
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
