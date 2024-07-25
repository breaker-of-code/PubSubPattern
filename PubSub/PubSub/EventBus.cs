using System;
using System.Collections.Generic;

namespace PubSub
{
    public enum EventCode
    {
        Event1,
        Event2,
    }

    
    public class EventBus
    {
        private static EventBus _instance;
        private readonly Dictionary<EventCode, List<Action>> _eventDictionary;

        private EventBus()
        {
            _eventDictionary = new Dictionary<EventCode, List<Action>>();
        }

        public static EventBus Instance => _instance ?? (_instance = new EventBus());

        public void Subscribe(EventCode eventCode, Action listener)
        {
            if (_eventDictionary.TryGetValue(eventCode, out var listeners))
            {
                listeners.Add(listener);
            }
            else
            {
                listeners = new List<Action> { listener };
                _eventDictionary[eventCode] = listeners;
            }
        }

        public void Unsubscribe(EventCode eventCode, Action listener)
        {
            if (_eventDictionary.TryGetValue(eventCode, out var listeners))
            {
                listeners.Remove(listener);
            }
        }

        public void Publish(EventCode eventCode)
        {
            if (!_eventDictionary.TryGetValue(eventCode, out var listeners)) return;
            
            foreach (var listener in listeners)
            {
                listener.Invoke();
            }
        }
    }
}