using System;
using System.Collections.Generic;
using Services;

namespace Notifications
{
    public class EventBus
    {
        #region Fields

        private readonly Dictionary<GameplayEventType, List<Action<EventParams>>>
            _subscribers = new Dictionary<GameplayEventType, List<Action<EventParams>>>();

        #endregion

        #region Methods

        public void Subscribe(GameplayEventType eventType, Action<EventParams> callback)
        {
            if (!_subscribers.ContainsKey(eventType))
            {
                _subscribers.Add(eventType, new List<Action<EventParams>>());
            }

            _subscribers[eventType].Add(callback);
        }

        public void Unsubscribe(GameplayEventType eventType, Action<EventParams> callback)
        {
            if (!_subscribers.ContainsKey(eventType))
            {
                throw new InvalidOperationException(("Can't unsubscribe, there is no such subscription"));
            }

            _subscribers[eventType].Remove(callback);
        }

        public void Publish(GameplayEventType eventType, EventParams parameters)
        {
            if (!_subscribers.ContainsKey(eventType))
            {
                return;
            }

            var subscribers = _subscribers[eventType];
            for (var i = 0; i < _subscribers[eventType].Count; i++)
            {
                var handler = subscribers[i];
                handler?.Invoke(parameters);
            }
        }

        #endregion
    }
}